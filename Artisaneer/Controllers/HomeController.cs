using Artisaneer.DataLayer;
using Artisaneer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Web.Http;
using System.Web.Mvc;


namespace Artisaneer.Controllers
{
    public class HomeController : Controller
    {
        public readonly IRegistrationRepository _irrepo;
        public HomeController(IRegistrationRepository irrepo)
        {
            _irrepo = irrepo;
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetStates()
        {
            var rStates = _irrepo.GetStates();
            return Json(rStates, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetLGA(int stateId)
        {
            var stateLGA = _irrepo.GetLGA(stateId);
            return Json(stateLGA,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSkills()
        {
            var skills = _irrepo.GetSkills();
            return Json(skills, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult GetAll()
        //{
        //        var ret = _irrepo.GetOnce();    
        //        return Json(ret, JsonRequestBehavior.AllowGet);
        //}
            
        }
    }

