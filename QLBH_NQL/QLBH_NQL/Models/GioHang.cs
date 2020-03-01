using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLBH_NQL.Models;
namespace QLBH_NQL.Models
{
    public class GioHang
    {
        public int MAHOA { get; set; }
        public string ANHHOA { get; set; }
        public string TENHOA { get; set; }
        public Decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public Decimal ThanhTien
        {
            get { return DonGia * SoLuong; }
        }

    }
}