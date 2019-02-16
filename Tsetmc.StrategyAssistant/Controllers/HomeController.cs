using System.Web.Mvc;
using Tsetmc.StrategyAssistant.Models;
using TsetmcLib;

namespace Tsetmc.StrategyAssistant.Controllers
{
    public class HomeController : Controller
    {
        const int boors = 1;
        const int fara = 2;
        SimpleFilter filterer;
        FilterByPBE pbefilterer;
        public HomeController()
        {
            filterer = new SimpleFilter();
            pbefilterer = new FilterByPBE();

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
        [HttpPost]
        public ActionResult FilterByPBE(FilterByPBEModel model)
        {
            var boorsFilterByPBE = new FilterByPBEParamModel(model.LastDaysAllowedChange, model.TodayAllowedChange, model.PbeMinChange, model.PbeMaxChange, model.Market);
            var BoorsAllowed = pbefilterer.GetAllowed(boorsFilterByPBE);
            return Json(BoorsAllowed, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}