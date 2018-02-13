using GettingStartedWithKnockout.Models.Courses;
using GettingStartedWithKnockout.Models.Registration;
using System.Web.Http;
using System.Web.Mvc;

namespace GettingStartedWithKnockout.Controllers
{
    //Here we have two end-point
    public class CoursesController : ApiController
    {
        private readonly RegistrationVmBuilder _registrationVmBuilder = new RegistrationVmBuilder();
        public CourseVm[] Get()
        {
            return _registrationVmBuilder.GetCoursesVm();
        }

    }
}
