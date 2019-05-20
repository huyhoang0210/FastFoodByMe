using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fast_food1.Models;

namespace Fast_food1.Controllers
{
    public class DangNhapController : Controller
    {
        FastFoodDbContext db = new FastFoodDbContext();
        // GET: DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string tk = Request.Form["MaND"];
            string mk = Request.Form["MatKhau"];
            NguoiDung taikhoan = db.NguoiDungs.SingleOrDefault(t => t.HoTen == tk && t.MatKhau.Trim() == mk);
            if(taikhoan != null)
            {
                Session["DangNhap"] = taikhoan;
                return RedirectToAction("index", "Home");
            }
            ViewBag.mess = "Dang nhap that bai";
            return RedirectToAction("DangNhap", "DangNhap");
        }
        public ActionResult DangKi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKi(FormCollection f)
        {
            NguoiDung taikhoan = new NguoiDung();
            taikhoan.HoTen = Request.Form["HoTen"];
            taikhoan.MatKhau = Request.Form["MatKhau"];
            taikhoan.SDT = Request.Form["SDT"];
            //taikhoan.NgaySinh =Request.Form["NgaySinh"];
            db.NguoiDungs.Add(taikhoan);
            db.SaveChanges();
            return RedirectToAction("DangNhap", "DangNhap");

        }
        public ActionResult DangXuat()
        {
            Session["DangNhap"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}