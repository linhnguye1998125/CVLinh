using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBH_NQL.Models;

namespace QLBH_NQL.Controllers
{
    public class NavBarController : Controller
    {
        // GET: Navbar
        QLBHModel db = new QLBHModel();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult NavBarPartial()
        {
            string menu = "";
            var danhmuchoa = (from p in db.DANHMUCHOAs select p).Where(p => p.HIDEN == true).ToList();

            if (danhmuchoa.Count() > 0)
            {
                menu += "<ul class='nav navbar-nav'>";
                for (int i = 0; i < danhmuchoa.Count(); i++)
                {
                    if (danhmuchoa[i].MADM != "SP")
                    {
                        menu += "<li><a href=" + danhmuchoa[i].HREF + " ref='nofollow'>" + danhmuchoa[i].TENDM + "</a></li>";
                    }
                    else
                    {

                        var danhmuccon = (from c in db.DANHMUCCONs select c).Where(c => c.MADM == "SP" && c.HIDEN == true).ToList();
                        if (danhmuccon.Count() > 0)
                        {
                            menu += "<li class='dropdown'><a class='dropdown-toggle' data-toggle='dropdown' href='javascript: 0'>" + danhmuchoa[i].TENDM + "<span class='caret'></span></a>";
                            menu += "<ul class='dropdown-menu color-submenu'>";
                            string MADMH = "";
                            for (int j = 0; j < danhmuccon.Count(); j++)
                            {
                                MADMH = danhmuccon[j].MADMH;
                                menu += "<li><a href='HoaTheoLoai?MADMH=" + MADMH + "'>" + danhmuccon[j].TENDMCON + "</a></li>";
                            }
                            menu += "</ul>";
                            menu += "</li>";
                        }
                    }

                }

                menu += "</ul>";
            }
            ViewBag.View = menu;
            return PartialView();
        }

    }
}