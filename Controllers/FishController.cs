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
        FishContext db;

        public ActionResult Next(string setName)
        {
            db = new FishContext();
            var foodSet = db.Sets.Where(s => s.Name == setName).FirstOrDefault();
            if (foodSet == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            rowIndex++;
            Fish fish = foodSet.Fishes.ToList().Find(f => f.FishInnerId == rowIndex);
            if(fish == null)
            {
                return Json("thatsIt", JsonRequestBehavior.AllowGet);
            }

            FishVM fishVM = new FishVM { 
                EspContent = fish.EspContent, 
                PlContent = fish.PlContent, 
                SetLength = foodSet.Fishes.Count() };

            return Json(fishVM, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Guess(string setName)
        {
            ViewBag.setName = setName;
            rowIndex = 0;

            return View();
        }
    }
}