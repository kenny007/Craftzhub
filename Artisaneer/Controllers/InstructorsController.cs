using GettingStartedWithKnockout.Models.Courses;
using GettingStartedWithKnockout.Models.Registration;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace GettingStartedWithKnockout.Controllers
{
    public class InstructorsController : ApiController 
    {
       
            private readonly RegistrationVmBuilder _registrationVmBuilder = new RegistrationVmBuilder();
            public InstructorVm[] Get()
            {
                return _registrationVmBuilder.GetInstructorsVm();
            }


    }
}
