using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using QLBH_NQL.Models;

namespace QLBH_NQL.Controllers
{
    public class HomeController : Controller
    {
            public static int mahoa = 1;
            QLBHModel db = new QLBHModel();
            public ActionResult Index()
            {
                return Redirect("~/Trang-Chu");
            }
            public ActionResult TrangChu()
            {
                var Hoa = db.HOAs.Take(12).ToList();
                //ModelState.Clear();
                return View(Hoa);
            }
            public ActionResult GioiThieu()
            {
                return View();
            }
            public ActionResult ThanhCong()
            {
                return View();
            }
            public ActionResult TinTuc()
            {
                var tintuc = db.TINTUCs.ToList();
                return View(tintuc);
            }

            public ActionResult ChiTietHoa(int MAHOA = 0)
            {
                HOA hoa = db.HOAs.SingleOrDefault(m => m.MAHOA == MAHOA);
                if (hoa == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                hoa.SOLANXEM = hoa.SOLANXEM + 1;
                UpdateModel(hoa);
                db.SaveChanges();
                mahoa = MAHOA;
                return View(hoa);
            }

            public ActionResult HoaTheoLoai(string MADMH = "")
            {
                var hoa = db.HOAs.Where(m => m.MADMH == MADMH).ToList();
                if (hoa == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                DANHMUCCON DM = db.DANHMUCCONs.SingleOrDefault(m => m.MADMH == MADMH);
                ViewBag.TieuDe = DM.TENDMCON;
                return View(hoa);
            }
            public string FormatPrice(string _strInput)
            {
                string strInput = _strInput;
                int Length = 0;
                if (strInput.IndexOf(',') > 0)
                    Length = strInput.Length - (strInput.Length - strInput.IndexOf(','));
                else
                    Length = strInput.Length;
                string afterFormat = "";
                if (Length <= 3)
                    afterFormat = strInput;
                else if (Length > 3)
                {
                    afterFormat = strInput.Insert(Length - 3, ",");
                    Length = afterFormat.IndexOf(",");
                    while (Length > 3)
                    {
                        afterFormat = afterFormat.Insert(Length - 3, ",");
                        Length = Length - 3;
                    }
                }
                return afterFormat;
            }
            public string ktconhang(int sl)
            {
                string trangthai = "Còn hàng";
                if (sl <= 0)
                {
                    trangthai = "Hết hàng";
                }
                return trangthai;
            }
            public ActionResult GioHang()
            {
                var cart = Session["GioHang"];
                var list = new List<GioHang>();
                if (cart != null)
                {
                    list = (List<GioHang>)cart;
                }
                return View(list);
            }
            public ActionResult AddItem(int soluong = 1)
            {
                int MaHoa = mahoa;
                if (Session["GioHang"] == null) // Nếu giỏ hàng chưa được khởi tạo
                {
                    Session["GioHang"] = new List<GioHang>();  // Khởi tạo Session["giohang"] là 1 List<GioHang>
                }
                List<GioHang> giohang = Session["GioHang"] as List<GioHang>;  // Gán qua biến giohang dễ code

                // Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa
                if (giohang.FirstOrDefault(m => m.MAHOA == MaHoa) == null) // ko co sp nay trong gio hang
                {
                    HOA sp = db.HOAs.Find(MaHoa);
                    // tim sp theo MaHoa
                    GioHang sanpham = new GioHang()
                    {
                        MAHOA = MaHoa,
                        ANHHOA = sp.ANHHOA,
                        TENHOA = sp.TENHOA,
                        SoLuong = soluong,
                        DonGia = Decimal.Parse(sp.DONGIA.ToString())

                    };  // Tạo ra 1 sản phẩm mới

                    giohang.Add(sanpham);  // Thêm sản phẩm vào giỏ 
                }
                else
                {
                    // Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                    GioHang sanpham = giohang.FirstOrDefault(m => m.MAHOA == MaHoa);
                    sanpham.SoLuong++;
                }
                return RedirectToAction("GioHang");
            }
            public JsonResult Update(string CartModel)
            {
                var GioHang = new JavaScriptSerializer().Deserialize<List<GioHang>>(CartModel);
                var session = (List<GioHang>)Session["GioHang"];
                foreach (var item in session)
                {
                    var jsonItem = GioHang.SingleOrDefault(n => n.MAHOA == item.MAHOA);
                    if (jsonItem != null)
                    {
                        item.SoLuong = jsonItem.SoLuong;
                    }
                }
                return Json(new
                {
                    status = true
                });
            }
            public JsonResult Delete(int MAHOA)
            {
                var GioHang = (List<GioHang>)Session["GioHang"];
                GioHang.RemoveAll(k => k.MAHOA == MAHOA);
                return Json(new
                {
                    status = true
                });
            }

            [HttpGet]
            public ActionResult ThanhToan()
            {
                var cart = Session["GioHang"];
                var list = new List<GioHang>();
                if (cart != null)
                {
                    list = (List<GioHang>)cart;
                }
                try
                {
                    int MaKH = int.Parse(Session["MAKH"].ToString());
                    var KH = db.KHACHHANGs.SingleOrDefault(n => n.MAKH == MaKH);
                    ViewBag.Name = KH.TENKH;
                    ViewBag.Email = KH.EMAIL;
                    ViewBag.DiaChi = KH.DIACHI;
                }
                catch (Exception ex)
                {
                    //Response.Redirect("~/UserAccount/DangNhap");
                }
                return View(list);
            }
            [HttpPost]
            public ActionResult ThanhToan(string name, string email, string sdt, string diachi, string htthanhtoan, string htgiaohang)
            {
                var GioHang = (List<GioHang>)Session["GioHang"];
                var donhang = new DONDATHANG();
                donhang.MAKH = int.Parse(Session["MAKH"].ToString());
                donhang.NGAYDATHANG = DateTime.Now;
                donhang.TENNGUOINHAN = name;
                donhang.DIENTHOAI = sdt;
                donhang.DIACHI = diachi;
                donhang.HTTHANHTOAN = htthanhtoan;
                donhang.HTGIAOHANG = htgiaohang;
                donhang.TRIGIA = Tongtien();
                try
                {
                    var MaKH = them(donhang);
                    foreach (var item in GioHang)
                    {
                        var CTDONHANG = new CTDATHANG();
                        CTDONHANG.MADH = donhang.MADH;
                        CTDONHANG.MAHOA = item.MAHOA;
                        CTDONHANG.SOLUONG = item.SoLuong;
                        CTDONHANG.DONGIA = item.DonGia;
                        CTDONHANG.THANHTIEN = item.ThanhTien;
                        var Hoa = db.HOAs.SingleOrDefault(n => n.MAHOA == item.MAHOA);
                        Hoa.TONGSOLUONG = Hoa.TONGSOLUONG - item.SoLuong;
                        UpdateModel(Hoa);
                        db.CTDATHANGs.Add(CTDONHANG);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                if (htthanhtoan == "giaohang")
                {
                    Response.Redirect("~/Home/ThanhCong");
                }
                else if (htthanhtoan == "baokim")
                {
                    Response.Redirect("https://www.baokim.vn/thanh-toan/home/paymentMethod?oid=YDSXwCSpuN8%3D&gindex=4");
                }
                else
                {
                    Response.Redirect("");
                }
                Session["GioHang"] = null;
                return Redirect("~/Home/TrangChu");
            }
            public Decimal Tongtien()
            {
                var GioHang = (List<GioHang>)Session["GioHang"];
                Decimal Tong = 0;
                foreach (var item in GioHang)
                {
                    Tong += item.ThanhTien;
                }
                return Tong;
            }
            public long them(DONDATHANG donhang)
            {
                db.DONDATHANGs.Add(donhang);
                db.SaveChanges();
                return int.Parse(donhang.MAKH.ToString());
            }
            public ActionResult TimKiem(string txttimkiem)
            {
                var Hoa = db.HOAs.SqlQuery("select * from HOA Where TENHOA like '" + txttimkiem + "%'").ToList();
                return View(Hoa);
            }
        }
}