using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBH_NQL.Models;
namespace QLBH_NQL.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: UserAccount
        QLBHModel db = new QLBHModel();

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(KHACHHANG kh)
        {
            if (ModelState.IsValid)
            {
                db.KHACHHANGs.Add(kh);
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string UserName = f["TENDN"].ToString();
            string Passwork = f["MATKHAU"].ToString();
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.TENDN == UserName && n.MATKHAU == Passwork);
            if (kh != null)
            {
                Session["MAKH"] = kh.MAKH;
                Session["TENDN"] = kh.TENKH;
                ViewBag.TenKH = kh.TENKH;
                Response.Redirect("~/Home/TrangChu");
            }
            else
            {
                Response.Write("<script>alert('Bạn vui lòng kiểm tra lại tên tài khoản và mật khẩu!')</script>");
            }
            return View(kh);
        }

        public PartialViewResult UserAccountPartial()
        {
            return PartialView();
        }
        public void DangXuat()
        {
            Session["TENDN"] = null;
            Response.Redirect("~/Home/TrangChu");
        }
        public ActionResult ThongTinKhachHang()
        {
            var dao = new UserDao();
            if (Session["MAKH"] != null)
            {

                KHACHHANG k = dao.ThongTinKhachHang(int.Parse(Session["MAKH"].ToString()));
                return View(k);
            }
            else return RedirectToAction("DangNhap");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThongTinKhachHang(FormCollection f)
        {
            int MAKH = int.Parse(Session["MAKH"].ToString());
            var dao = db.KHACHHANGs.SingleOrDefault(n => n.MAKH == MAKH);
            dao.MAKH = MAKH;
            dao.TENDN = f["TENDN"].ToString();
            dao.TENKH = f["TENKH"].ToString();
            dao.NGAYSINH = DateTime.Parse(f["NGAYSINH"].ToString());
            dao.EMAIL = f["EMAIL"].ToString();
            dao.DIACHI = f["DIACHI"].ToString();
            UpdateModel(dao);
            db.SaveChanges();
            return View("ThongTinKhachHang");
        }
        public ActionResult DoiMatKhau()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoiMatKhau(DoiMatKhauModel model)
        {
            int id = int.Parse(Session["MAKH"].ToString());
            var dao = new UserDao();
            if (dao.KiemTraMatKhau(id, model.MatKhauCu) == true)
            {
                dao.LuuMatKhau(id, model.MatKhauMoi);
                return RedirectToAction("DangNhap");
            }
            return View();
        }
    }
}