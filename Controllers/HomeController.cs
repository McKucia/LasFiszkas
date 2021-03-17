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
        //private FishContext db = new FishContext();

        public ActionResult Main()
        {
            return View();
        }

        public ActionResult NewSet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewSet(List<Fish> fishes)
        {
            /*            if (!ModelState.IsValid)
                            return View(fishes);

                        else
                        {
                            Set newSet = new Set { Name = "Test", Description = "Test to jest", IconFilename = "test.png" };
                            db.Sets.Add(newSet);

                            foreach (var f in fishes) {
                                f.Set = newSet;
                                db.Fishes.Add(f);
                            }
                            db.SaveChanges();
                            return View();
                        }*/
            return View();
        }

        public ActionResult Guess(string setName)
        {
            FishContext db = new FishContext();
            var foodSet = db.Sets.Where(s => s.Name == setName).FirstOrDefault();
            if(foodSet == null)
            {
                Response.StatusCode = 404;
                Response.TrySkipIisCustomErrors = true;
                return View("my404Error");
            }
            var fishes = foodSet.Fishes.ToList();


            return View(fishes);
        }
    }
}