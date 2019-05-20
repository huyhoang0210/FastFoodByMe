using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fast_food1.Models;
namespace Fast_food1.Controllers
{
    public class GioHangController : Controller
    {
        FastFoodDbContext db = new FastFoodDbContext();
        // GET: GioHang
        public List<GioHang> Laygiohang()
        {
            List<GioHang> lstgiohang = Session["GioHang"] as List<GioHang>;
            if (lstgiohang == null)
            {
                lstgiohang = new List<GioHang>();
                Session["GioHang"] = lstgiohang;
            }
            return lstgiohang;
        }
        public ActionResult ThemGioHang(int ma, string url)
        {
            Mon mon = db.Mons.SingleOrDefault(n => n.MaMon == ma);
            if (mon == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstgiohang = Laygiohang();
            GioHang sp = lstgiohang.Find(n => n.mamon == ma);
            if (sp == null)
            {
                sp = new GioHang(ma);
                lstgiohang.Add(sp);
                return Redirect(url);
            }
            else
            {
                sp.soluong++;
                return Redirect(url);
            }
        }
        public ActionResult CapNhatGioHang(int Masp, FormCollection f)
        {
            Mon m = db.Mons.SingleOrDefault(n => n.MaMon == Masp);
            if (m == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = Laygiohang();
            GioHang sp = lstGioHang.SingleOrDefault(n => n.mamon == Masp);
            if (sp != null)
            {
                sp.soluong = int.Parse(f["num-order"].ToString());
            }
            return View("GioHang");
        }
        public ActionResult XoaGioHang(int ma)
        {
            Mon m = db.Mons.SingleOrDefault(n => n.MaMon == ma);
            if (m == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = Laygiohang();
            GioHang sp = lstGioHang.SingleOrDefault(n => n.mamon == ma);
            if (sp != null)
            {
                lstGioHang.RemoveAll(n => n.mamon == ma);

            }
            if (lstGioHang.Count == 0)
            {
                RedirectToAction("index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("index", "Home");
            }
            List<GioHang> lstGioHang = Laygiohang();
            return View(lstGioHang);
        }
        private int TongSoLuong()
        {
            int TongSL = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                TongSL = lstGioHang.Sum(n => n.soluong);
            }
            return TongSL;
        }
        private int TongTien()
        {
            int TongT = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                TongT = int.Parse(lstGioHang.Sum(n => n.tongtien).ToString());
            }
            return TongT;
        }
    }
}
