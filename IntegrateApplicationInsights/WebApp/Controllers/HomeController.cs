﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Integrate Application Insights";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Integrate Application Insights";

			return View();
		}
	}
}