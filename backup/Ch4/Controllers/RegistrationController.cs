using GettingStartedWithKnockout.Models.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GettingStartedWithKnockout.Controllers
{
    public class RegistrationController : Controller
    {
        //private RegistrationVmBuilder _registrationVmBuilder = new RegistrationVmBuilder();
        public ActionResult Index()
        {
            return View();
        }

    }
}
