using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fast_food1.Models;
namespace Fast_food1.Controllers
{
    public class BlogController : Controller
    {
        FastFoodDbContext db = new FastFoodDbContext();
        // GET: Blog
        //public ActionResult Blog()
        //{
        //    return View();
        //}

        public ActionResult Blog()
        {
            var blog = db.blogs.Take(3).ToList();
            return View(blog);
        }
    }
}