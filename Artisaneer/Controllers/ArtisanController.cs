using Artisaneer.DataLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;
//using System.Web.Mvc;

namespace Artisaneer.Controllers
{
    // [Authorize(Roles = "Artisan")]
    public class ArtisanController : Controller
    {
        //
        // GET: /Artisan/
        public readonly IArtisanRepository _arttrepo;
       
        public ArtisanController(IArtisanRepository artrepo){
            _arttrepo = artrepo;
        }

        public JsonResult GetArtisans(string q = null, string sort = null, bool desc = false,
                                                       int? limit = null, int offset = 0)
        {
            return Json(_arttrepo.SearchArtisans(q, sort, desc, limit, offset), JsonRequestBehavior.AllowGet);
        }

        // GET api/Artisan
        public JsonResult GetAll() {
            return Json(_arttrepo.GetArts(), JsonRequestBehavior.AllowGet);
        }

        //public JsonResult Index() 
        //{
        //    return Json(_arttrepo.GetArts(), JsonRequestBehavior.AllowGet);
        //}
        public ActionResult Index() {
            return View();
        }

      
    }
}
