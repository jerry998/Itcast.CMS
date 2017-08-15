﻿using Itcast.CMS.WebApp.ActionFilters;
using System.Web;
using System.Web.Mvc;

namespace Itcast.CMS.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthenticationFilterAttribute());
        }
    }
}