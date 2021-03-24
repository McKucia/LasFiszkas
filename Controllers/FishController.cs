using LasFiszkas.DAL;
using LasFiszkas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LasFiszkas.Controllers
{
    public class FishController : Controller
    {
        public static int rowIndex;

        public ActionResult Next(string setName)
        {
            FishContext db = new FishContext();
            var foodSet = db.Sets.Where(s => s.Name == setName).FirstOrDefault();
            if (foodSet == null)
            {
                Response.StatusCode = 404;
                Response.TrySkipIisCustomErrors = true;
                return View("my404Error");
            }

            rowIndex++;
            Fish fish = foodSet.Fishes.ToList().Find(f => f.FishInnerId == rowIndex);
            FishVM fishVM = new FishVM { EspContent = fish.EspContent, PlContent = fish.PlContent };
            

            return Json(fishVM, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Guess(string setName)
        {
            rowIndex = 0;
            return View((object)setName);
        }
    }
}