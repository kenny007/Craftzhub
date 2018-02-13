using Artisaneer.Models.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Artisaneer.Models.Registration
{
    public class RegistrationVmBuilder
    {
  
        public CourseVm[] GetCoursesVm()
        {
            var courses = new[]
             {
               new CourseVm {Number="CREAT8", Name="Mathematics",Instructor="Ashifat"},
               new CourseVm {Number="CRIMSON8",Name="Yoruba",Instructor="Baba Yoruba"},
               new CourseVm {Number="SEASON8",Name="English",Instructor="Udoh"},
             };
            return courses;
        }

        public InstructorVm[] GetInstructorsVm()
        {
            var instructors = new[]
             {
               new InstructorVm {Name ="OTU108", Email ="Plant Physiology",RoomNumber = 1004},
               new InstructorVm {Name ="CRIMSON8", Email="Plant Genetics",RoomNumber = 1001},
               new InstructorVm {Name ="BIOM678", Email="Biometrics",RoomNumber = 2009},
             };
            return instructors;
        }    
    }
}