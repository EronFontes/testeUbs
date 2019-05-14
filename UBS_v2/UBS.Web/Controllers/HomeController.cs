using Core.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Interfaces;

namespace UBS.Web.Controllers
{
    /// <summary>
    /// HomeController.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// Middleware.
        /// </summary>
        /// <returns></returns>
        public JsonResult Middleware()
        {
            return Json(PeopleProvider.ListPeople, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Contact.
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            return View();
        }
    }
}