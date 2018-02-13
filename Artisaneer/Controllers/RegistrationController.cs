using Artisaneer.DataLayer;
using Artisaneer.Models.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Artisaneer.Controllers
{
    public class RegistrationController : Controller
    {
        //private RegistrationVmBuilder _registrationVmBuilder = new RegistrationVmBuilder();
        public readonly IRegistrationRepository _irrepo;
        public RegistrationController( IRegistrationRepository irrepo)
        {
            _irrepo = irrepo;
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}
