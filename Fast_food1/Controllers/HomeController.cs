using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fast_food1.Models;
namespace Fast_food1.Controllers
{
    public class HomeController : Controller
    {
        FastFoodDbContext db = new FastFoodDbContext();
        public ActionResult Index(decimal? Min,decimal? Max,string TKTen)
        {
            //var   ListMon = db.Mons.Take(12).ToList();
            List<Mon> list = new List<Mon>();
            if(Min != null && Max != null)

            {
                list = db.Mons.Where(s => s.Gia >= Min && s.Gia <= Max).ToList();
            }
          else if (Max != null)
            {
                list = db.Mons.Where(s => s.Gia <= Max).ToList();
            }
            else if (Min != null)
            {
                list = db.Mons.Where(s => s.Gia >= Min).ToList();
            }
            else if (TKTen != null)
            {
                list = db.Mons.Where(s => s.TenMon.Contains(TKTen)).ToList();
            }
            else 
            {
                list = db.Mons.Take(12).ToList();
            }
           
            return View(list);
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
