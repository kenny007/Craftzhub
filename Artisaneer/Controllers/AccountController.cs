using System.Web.Mvc;
using Artisaneer.Models;
using System.Net.Http;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using Artisaneer.Models.Registration;
using Artisaneer.Models.Courses;
using Artisaneer.DataLayer;
using System.Web.Routing;
using System.Web.Security;
using System;
//using System.Web.Http;
using WebMatrix.WebData;

namespace Artisaneer.Controllers
{ 
   // [System.Web.Http.Authorize]
    public class AccountController : Controller
    {
        public artMembershipProvider MembershipService { get; set; }
        public artRoleProvider AuthorizationService { get; set; }

        public readonly IAccountRepository _arepo;
        public AccountController(IAccountRepository arepo)
        {
            _arepo = arepo;
        }

        protected override void Initialize(RequestContext requestContext)
        {
            if (MembershipService == null)
                MembershipService = new artMembershipProvider();
            if (AuthorizationService == null)
                AuthorizationService = new artRoleProvider();

            base.Initialize(requestContext);
        }

        // GET: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public JsonResult Login(string returnUrl, LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Session["UserID"] = model.UserName;
               
                    if (MembershipService.ValidateUser(model.UserName, model.Password))
                    {
                         FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                         return Json(new { success = true });
                    }                    
            }
            return Json(new
            {
                success = false,
                errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                                .Select(m => m.ErrorMessage).ToArray()
            });
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
        
         //POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public JsonResult Register(HttpRequestMessage request,RegisterModel artisan)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user     
                try { 
                MembershipService.CreateUser(artisan.FirstName, artisan.UserName, artisan.Email, artisan.LastName, artisan.State, artisan.LocalGovt,
                    artisan.PhoneNumber, artisan.Address, artisan.Password, artisan.ConfirmPassword, "Artisan",artisan.SkillId, artisan);

                return Json(new {success = true});
              }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }
            // If we got this far, something failed, redisplay form
            return Json(new
            {
                success = false,
                errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                                .Select(m => m.ErrorMessage).ToArray()
            });
        }

        [AllowAnonymous]
        public JsonResult IsUserAvailable(string userName)
        {
           //bool st = MembershipService.CreateUser
            bool status = !WebSecurity.UserExists(userName);
            return Json(new { result = status });
        }

        private IEnumerable<string> GetErrorMessages() 
        {
             return ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);    
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }
}
