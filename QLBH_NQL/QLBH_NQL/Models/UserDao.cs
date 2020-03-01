using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLBH_NQL.Models;
namespace QLBH_NQL.Models
{
    public class UserDao
    {
        QLBHModel db = null;

        public UserDao()
        {
            db = new QLBHModel();
        }
        public HOA GetId(int Id)
        {
            return db.HOAs.SingleOrDefault(x => x.MAHOA == Id);
        }
        public long Insert(KHACHHANG entity)
        {
            db.KHACHHANGs.Add(entity);
            db.SaveChanges();
            return entity.MAKH;
        }

        public KHACHHANG GetbyID(string userName)
        {
            return db.KHACHHANGs.SingleOrDefault(x => x.TENDN == userName);
        }

        public KHACHHANG ThongTinKhachHang(int id)
        {
            return db.KHACHHANGs.SingleOrDefault(x => x.MAKH == id);
        }


        public bool KiemTraMatKhau(int id, string pass)
        {
            KHACHHANG K = db.KHACHHANGs.SingleOrDefault(x => x.MAKH == id);
            if (K.MATKHAU == pass)
            {
                return true;
            }
            return false;
        }


        //public void LuuThongTinKhachHang(int id, string TenDN,string TenKH,DateTime NgaySinh,string Email,string DiaChi)
        //{
        //    var User = (KHACHHANG)ThongTinKhachHang(id);

        //    User.TENDN =TenDN;
        //    User.TENKH = TenKH;
        //    User.NGAYSINH = NgaySinh;
        //    User.EMAIL = Email;
        //    User.DIACHI = DiaChi;
        //    db.KHACHHANGs.Attach(User);
        //    db.Entry(User).Property(x => x.TENDN).IsModified = true;
        //    db.SaveChanges();

        //}
        public void LuuMatKhau(int id, string pass)
        {
            var User = (KHACHHANG)ThongTinKhachHang(id);

            User.MATKHAU = pass;

            db.KHACHHANGs.Attach(User);
            db.Entry(User).Property(x => x.MATKHAU).IsModified = true;
            db.SaveChanges();

        }


    }
}