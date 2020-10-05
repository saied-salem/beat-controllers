using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beat.Interfaces;
using Beat.Model;
using Beat.Services;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Beat.Controllers
{
    public class HomeController : Controller
    {
        private IMemberService _memberService;
        private PartnerService ps;

        public HomeController()
        {
            _memberService = new MemberService();
            ps = new PartnerService();
        
    }
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }
        public ActionResult p_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(ps.GetAll().ToDataSourceResult(request));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
