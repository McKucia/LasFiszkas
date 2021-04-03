using LasFiszkas.App_Start;
using LasFiszkas.DAL;
using LasFiszkas.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var foundSet = db.Sets.Where(s => s.Name == setName).FirstOrDefault();
            if (foundSet == null)
            {
                return HttpNotFound();
            }

            rowIndex++;
            Fish fish = foundSet.Fishes.ToList().Find(f => f.FishInnerId == rowIndex);
            if(fish == null)
            {
                return Json("thatsIt", JsonRequestBehavior.AllowGet);
            }

            FishVM fishVM = new FishVM {
                EspContent = fish.EspContent,
                PlContent = fish.PlContent,
                SetLength = foundSet.Fishes.Count()
            };

            return Json(fishVM, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Guess(string setName)
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.setName = setName;
                rowIndex = 0;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Guess", "Cart") });
            }
        }
    }
}