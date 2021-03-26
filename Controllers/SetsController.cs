using LasFiszkas.DAL;
using LasFiszkas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace LasFiszkas.Controllers
{
    public class SetsController : Controller
    {
        public ActionResult NewSet() => View();

        [HttpPost]
        public ActionResult NewSet(List<Fish> fishes, HttpPostedFileBase uploadImage)
        {

            if (!ModelState.IsValid)
                return View(fishes);

            else
            {
                Set newSet;
                if (uploadImage != null)
                {
                    var imageLength = uploadImage.ContentLength;
                    byte[] input = new byte[imageLength];
                    uploadImage.InputStream.Read(input, 0, imageLength);
                    newSet = new Set { Name = "Test", Description = "Test to jest", ImageFIle = input };
                }
                else
                {
                    newSet = new Set { Name = "Test", Description = "Test to jest" };
                }


                FishContext db = new FishContext();
                db.Sets.Add(newSet);

                int innerId = 1;
                foreach (var f in fishes)
                {
                    f.FishInnerId = innerId;
                    innerId++;
                    f.Set = newSet;
                    db.Fishes.Add(f);
                }
                db.SaveChanges();

                return RedirectToAction("AllSets");
            }
        }

        public ActionResult AllSets()
        {
            FishContext db = new FishContext();
            var foodSets = db.Sets.ToList();

            return View(foodSets);
        }
    }
}