using LasFiszkas.DAL;
using LasFiszkas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LasFiszkas.Controllers
{
    public class HomeController : Controller
    {
        private FishContext db = new FishContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            Set newSet = new Set { Name = "Jedzenie", Description = "To co na stole masz", IconFilename = "1.png" };
            db.Sets.Add(newSet);
            db.SaveChanges();

            return View();
        }
    }
}