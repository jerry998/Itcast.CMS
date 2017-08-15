using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Itcast.CMS.WebApp.ActionFilters
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
             if ((string)filterContext.RouteData.Values["controller"] != "Login" && (string)filterContext.RouteData.Values["action"] != "ShowValidateCode")
            {
                if (HttpContext.Current.Session["UserInfo"] == null)
                {
                    //尚未登錄, 重新導向到登入頁面
                    filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary(new { controller = "Login", action = "Index" }));
                }
            }
        }
    }
}