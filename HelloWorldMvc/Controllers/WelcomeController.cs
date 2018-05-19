using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldMvc.Controllers
{
    public class WelcomeController : Controller
    {

        // GET: Welcome
        public ActionResult Index()
        {
            return View();
        }

        // GET: Welcome
        public ActionResult Bye()
        {
            return RedirectToAction("Hello", "Home");
        }

        // GET: Welcome/Anonyme
        public ActionResult Anonyme()
        {
            return View("AboutAnonyme");
        }

        // GET: Welcome/About
        public ActionResult About(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return RedirectToAction("Anonyme");
            }

            ViewData["nom"] = id;

            return View();
        }

        

    }
}