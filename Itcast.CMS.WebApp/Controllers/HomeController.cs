using Itcast.CMS.WebApp.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Itcast.CMS.WebApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //[AuthenticationFilter]  改加在 App_Start 中 FilterConfig
        [ActionName ("Index")]
        public ActionResult HomeIndex()
        {
            return View("Index");
        }

    }
}
