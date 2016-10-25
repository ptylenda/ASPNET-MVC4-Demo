using OperaWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperaWebSite.Controllers
{
    public class OperaController : Controller
    {
        //
        // GET: /Opera/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewOpera(int id)
        {
            return View("Opera");
        }

        public ActionResult AddOpera(Opera opera)
        {
        }

    }
}
