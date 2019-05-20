using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fast_food1.Models;
namespace Fast_food1.Controllers.Blog1
{
    public class CtBlogController : Controller
    {
        FastFoodDbContext db = new FastFoodDbContext();
       // GET: CtBlog
        public ActionResult ChiTietBlog(int ma)
        {
            blog m = db.blogs.SingleOrDefault(n => n.MaBlog == ma);
            return View(m);
        }
        //public ActionResult ChiTietBlog()
        //{
        //    return View();
        //}
    }
}