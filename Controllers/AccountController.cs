using LasFiszkas.App_Start;
using LasFiszkas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace LasFiszkas.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        private ApplicationSignInManager _signInManager;
        public ApplicationSignInManager SignInManager
        {
            get { return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
            private set { _signInManager = value; }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginVM model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser signedUser = UserManager.FindByEmail(model.Email);
            if(signedUser != null)
            {
                var result = await SignInManager.PasswordSignInAsync(signedUser.UserName, model.Password, model.RememberMe, shouldLockout: false);
                switch (result)
                {
                    case SignInStatus.Success:
                        return RedirectToLocal(returnUrl); //in order not do direct to other site
                    case SignInStatus.LockedOut:
                        return View("Lockout");
                    case SignInStatus.RequiresVerification:
                        return RedirectToAction("SendConde", new { ReturnUrl = returnUrl });
                    case SignInStatus.Failure:
                    default:
                        ModelState.AddModelError("loginerror", "Nieudana próba logowania.");
                        return View(model);
                }
            }
            ModelState.AddModelError("loginerror", "Nieudana próba logowania.");
            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Main", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterVM model, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.NickName,
                    Email = model.Email,
                    UserData = new UserData()
                    {
                        Email = model.Email,
                        NickName = model.NickName
                    }
                };

                if (uploadImage != null)
                {
                    var imageLength = uploadImage.ContentLength;
                    byte[] input = new byte[imageLength];
                    uploadImage.InputStream.Read(input, 0, imageLength);
                    user.UserData.ProfileImageFIle = input;
                }

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // Aby uzyskać więcej informacji o sposobie włączania potwierdzania konta i resetowaniu hasła, odwiedź stronę https://go.microsoft.com/fwlink/?LinkID=320771
                    // Wyślij wiadomość e-mail z tym łączem
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Potwierdź konto", "Potwierdź konto, klikając <a href=\"" + callbackUrl + "\">tutaj</a>");

                    return RedirectToAction("Main", "Home");
                }
                AddErrors(result);
            }

            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();

            return RedirectToAction("Main", "Home");
        }

        public async Task<ActionResult> Data()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                RegisterVM userVM = new RegisterVM()
                {
                    Email = user.UserData.Email,
                    NickName = user.UserData.NickName,
                    ProfileImageFIle = user.UserData.ProfileImageFIle
                };
                return View(userVM);
            }
            else
            {
                return RedirectToAction("Main", "Home");
            }
        }
    }
}