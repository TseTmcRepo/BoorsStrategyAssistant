using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tsetmc.StrategyAssistant.Models;
using TsetmcLib;
using DataTables.AspNet.Core;

namespace Tsetmc.StrategyAssistant.Controllers
{
    public class HomeController : Controller
    {
        const int boors = 1;
        const int fara = 2;
        SimpleFilter filterer;
        public HomeController()
        {
            filterer = new SimpleFilter();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(SimpleFilterModel model)
        {
            var boorsAllowedFilter = new AllowedMarketFilter(model.YesterdayAllowedChange , model.PositiveMinChange, model.PositiveMaxChange, model.Market);
            var BoorsAllowed = filterer.GetAllowed(boorsAllowedFilter);
            return Json(BoorsAllowed, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            var faraAllowedFilter = new AllowedMarketFilter(9.9m, 0.1m, 7.1m, fara);
            var faraAllowed = filterer.GetAllowed(faraAllowedFilter);

            return View(faraAllowed);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}