﻿using System.Web;
using System.Web.Mvc;

namespace _1_2_2023Task
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
