using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        ILogger logger;

        public HomeController(ILogger _logger)
        {
            logger = _logger;
        }


        public ActionResult Index()
        {
            logger.WriteLog("test");
            return View();
        }
    }
}