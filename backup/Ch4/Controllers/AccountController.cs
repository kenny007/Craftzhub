using System.Web.Mvc;
using System.Net;
using GettingStartedWithKnockout.Models;

namespace GettingStartedWithKnockout.Controllers
{  
    public class AccountController : Controller
    {
        [HttpPost]
        public ActionResult Save(StudentVm student) 
        {
            //_studentRegistrationService.Register(student)
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }
    }
}
