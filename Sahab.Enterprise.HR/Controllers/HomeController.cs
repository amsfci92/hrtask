using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sahab.Enterprise.HR.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Main Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // view the auth home page
            if (User.Identity.IsAuthenticated)
                return View("IndexAuth");
            // view the default hpme page
            return View();
        }
    }
}