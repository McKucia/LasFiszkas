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
using System.Web.Helpers;
using System.Web.Mvc;

namespace LasFiszkas.Controllers
{
    public class SetsController : Controller
    {
        public ActionResult NewSet()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("NewSet", "Sets") });
            }
        }

        [HttpPost]
        public ActionResult NewSet(List<Fish> fishes, string SetName, string SetDescription, HttpPostedFileBase uploadImage)
        {
            if (!ModelState.IsValid)
                return View(fishes);

            else
            {
                var currentUserId = User.Identity.GetUserId();
                Set newSet = new Set { Name = SetName, Description = SetDescription, UserId = currentUserId };
                if (uploadImage != null)
                {
                    var imageLength = uploadImage.ContentLength;
                    byte[] input = new byte[imageLength];
                    uploadImage.InputStream.Read(input, 0, imageLength);
                    newSet.ImageFIle = input;
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
            if (Request.IsAuthenticated)
            {
                string currentUserId = User.Identity.GetUserId();
                FishContext db = new FishContext();
                var foodSets = db.Sets.Where(s => s.UserId == currentUserId).ToList();

                return View(foodSets);
            }  

            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("AllSets", "Sets") });
            }
        }
    }
}