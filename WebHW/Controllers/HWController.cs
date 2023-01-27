using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebHW.Controllers
{
    public class HWController : Controller
    {
        // GET: HW
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GotoHome()
        {
            return View("HomePage");
        }
    }
}