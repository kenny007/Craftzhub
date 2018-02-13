using GettingStartedWithKnockout.Models.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GettingStartedWithKnockout.Controllers
{
    //Here we have two end-point
    public class CoursesController : JsonController
    {
        private readonly RegistrationVmBuilder _registrationVmBuilder = new RegistrationVmBuilder();
        public ActionResult Index()
        {
            return Json(_registrationVmBuilder.GetCoursesVm(), JsonRequestBehavior.AllowGet);
        }

    }
}
