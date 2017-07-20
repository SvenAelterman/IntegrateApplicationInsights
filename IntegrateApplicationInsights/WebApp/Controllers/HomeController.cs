using Microsoft.ApplicationInsights;
using System;
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
            var MyMetrics = new Dictionary<string, double>
            {
                { "Measure 1", DateTime.UtcNow.Hour },
                { "Measure 2", DateTime.UtcNow.Second }
            };
            new TelemetryClient().TrackEvent(nameof(Index), null, MyMetrics);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Integrate Application Insights";

            var MyMetrics = new Dictionary<string, double>
            {
                { "Measure 1", DateTime.UtcNow.Minute },
                { "Measure 2", DateTime.UtcNow.Second }
            };
            new TelemetryClient().TrackEvent(nameof(About), null, MyMetrics);

            return View();
        }

        public ActionResult Contact()
        {
            var MyMetrics = new Dictionary<string, double>
            {
                { "Measure 1", DateTime.UtcNow.Hour },
                { "Measure 2", DateTime.UtcNow.Second }
            };
            new TelemetryClient().TrackEvent(nameof(Contact), null, MyMetrics);

            ViewBag.Message = "Integrate Application Insights";

            return View();
        }
    }
}