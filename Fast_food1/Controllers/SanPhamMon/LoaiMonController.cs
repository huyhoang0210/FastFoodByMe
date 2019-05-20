using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fast_food1.Models;
namespace Fast_food1.Controllers.SanPhamMon
{
    public class LoaiMonController : Controller
    {
        FastFoodDbContext db = new FastFoodDbContext();
        // GET: LoaiMon
        public ActionResult LoaiMonPartial()
        {
            return View(db.LoaiMons.ToList());
        }
      public ActionResult TimTheoLoaiSP(int ma)
        {
            List<Mon> m = db.Mons.Where(n => n.MaLM == ma).ToList();
            return View(m);
        }
    }
}