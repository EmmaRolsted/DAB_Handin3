﻿using System.Web;
using System.Web.Mvc;

namespace F18DABH3Gr27
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
