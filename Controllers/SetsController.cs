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
        public ActionResult NewSet(/*List<Fish> fishes, */HttpPostedFileBase uploadImage)
        {
            var imageLength = uploadImage.ContentLength;
            byte[] input = new byte[imageLength];
            uploadImage.InputStream.Read(input, 0, imageLength);

            /*            if (!ModelState.IsValid)
                            return View(fishes);

                        else
                        {
                            FishContext db = new FishContext();
                            Set newSet = new Set { Name = "Test", Description = "Test to jest", IconFilename = "test.png" };
                            db.Sets.Add(newSet);

                            foreach (var f in fishes)
                            {
                                f.Set = newSet;
                                db.Fishes.Add(f);
                            }
                            db.SaveChanges();
                            return View();
                        }*/

            return View("ShowImage", input);
        }

        public ActionResult AllSets()
        {
            FishContext db = new FishContext();
            var foodSets = db.Sets.ToList();

            return View(foodSets);
        }
    }
}