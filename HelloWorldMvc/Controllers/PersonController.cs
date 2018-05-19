using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorldMvc.Models;

namespace HelloWorldMvc.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            ViewData["staffMembers"] = PersonManager.Personlist;

            return View();
        }

        // GET: Welcome/Team
        public ActionResult Browse()
        {
            ViewBag.staffMembers = PersonManager.Personlist;

            return View();
        }

        // GET: Welcome/Team
        public ActionResult Details(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return RedirectToAction("Team");
            }

            ViewData["person"] = id;
            ViewBag.isMember = PersonManager.Personlist.Contains(id);

            return View();
        }
    }
}