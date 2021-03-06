﻿using System.Web;
using System.Web.Mvc;

namespace my_vidly
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			filters.Add(new AuthorizeAttribute());
			filters.Add(new RequireHttpsAttribute());
		}
	}
}
