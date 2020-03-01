using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBH_NQL.Models;

namespace QLBH_NQL.Controllers
{
    public class BannerController : Controller
    {
        // GET: Banner
        QLBHModel db = new QLBHModel();
        [ChildActionOnly]
        public PartialViewResult BannerPartial()
        {
            var cart = Session["GioHang"];
            var list = new List<GioHang>();
            if (cart != null)
            {
                list = (List<GioHang>)cart;
            }
            return PartialView(list);
        }
        //public ActionResult LayLoGo(int thutu, bool trangthai)
        //{
        //    QUANGCAO qc = db.QUANGCAOs.SingleOrDefault(p => p.THUTUQC == thutu && p.TRANGTHAI == trangthai);
        //    ViewBag.QuangCao = qc.ANH;
        //    return View();
        //}
        public string LayLoGo(int thutu, bool trangthai)
        {
            QUANGCAO qc = db.QUANGCAOs.SingleOrDefault(p => p.THUTUQC == thutu && p.TRANGTHAI == trangthai);
            string quangcao = qc.ANH;
            quangcao = "~/Image/" + quangcao;
            return quangcao;
        }

    }
}