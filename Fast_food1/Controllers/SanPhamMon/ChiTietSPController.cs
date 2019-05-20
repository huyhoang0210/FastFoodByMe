using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fast_food1.Models;

namespace Fast_food1.Controllers.SanPhamMon
{
    public class ChiTietSPController : Controller
    {
        FastFoodDbContext db = new FastFoodDbContext();
        // GET: ChiTietSP
        public ActionResult CTMon(int Mamon )
        {
            Mon mon = db.Mons.SingleOrDefault(n => n.MaMon == Mamon);
            return View(mon);   
        }
        //public ActionResult CTMon()
        //{
        //    var ctmon = db.Mons.Take(1);
        //    return View(ctmon);
        //}
    }
}