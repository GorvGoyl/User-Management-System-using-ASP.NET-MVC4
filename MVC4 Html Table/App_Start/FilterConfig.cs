﻿using System.Web;
using System.Web.Mvc;

namespace MVC4_Html_Table
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}