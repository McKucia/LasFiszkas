using LasFiszkas.App_Start;
using LasFiszkas.DAL;
using LasFiszkas.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace LasFiszkas.Controllers
{
    public class SetsController : Controller
    {
        FishContext db;

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
        public ActionResult NewSet(List<Fish> fishes, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
                return View(fishes);

            else
            {
                var currentUserId = User.Identity.GetUserId();
                Set newSet = new Set { Name = fishes[0].Set.Name , UserId = currentUserId };
                newSet.Description = fishes[0].Set.Description != null ? fishes[0].Set.Description : null;

                if (file != null)
                {
                    var imageLength = file.ContentLength;
                    byte[] input = new byte[imageLength];
                    file.InputStream.Read(input, 0, imageLength);
                    newSet.ImageFIle = input;
                }

                db = new FishContext();
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
                db = new FishContext();
                var sets = db.Sets.Where(s => s.UserId == currentUserId).ToList();

                return View(sets);
            }  

            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("AllSets", "Sets") });
            }
        }

        public ActionResult Delete(int setId)
        {
            if (Request.IsAuthenticated) 
            {
                db = new FishContext();
                var delSet = db.Sets.Find(setId);
                if (delSet != null)
                {
                    db.Sets.Remove(delSet);
                    db.SaveChanges();
                }
                return RedirectToAction("AllSets");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Edit(int setId)
        {
            if (Request.IsAuthenticated)
            {
                db = new FishContext();
                var editSet = db.Sets.Find(setId);
                if (editSet == null)
                {
                    return HttpNotFound();
                }

                return View(editSet);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Name,Description,Fishes,ImageFile")]Set set, int setId, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
                return View(set);

            else
            {
                db = new FishContext();
                var editSet = db.Sets.Find(setId);
                editSet.Name = set.Name;
                editSet.Description = set.Description != null ? set.Description : null;
                if (file != null)
                {
                    var imageLength = file.ContentLength;
                    byte[] input = new byte[imageLength];
                    file.InputStream.Read(input, 0, imageLength);
                    editSet.ImageFIle = input;
                }
                int i = 0;
                foreach (var f in editSet.Fishes)
                {
                    f.PlContent = set.Fishes.ElementAt(i).PlContent;
                    f.EspContent = set.Fishes.ElementAt(i).EspContent;
                    i++;
                }

                db.Entry(editSet).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("AllSets");
            }
        }
    }
}