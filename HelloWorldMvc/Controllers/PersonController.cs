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
        public static List<string> Personlist { get; protected set; } = new List<string>()
        {
            "pierre",
            "paul",
            "jacques",
        };

        // GET: Person
        public ActionResult Index()
        {
            ViewData["staffMembers"] = Personlist;

            return View();
        }

        // GET: Welcome/Team
        public ActionResult Browse()
        {
            ViewBag.staffMembers = Personlist;

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
            ViewBag.isMember = Personlist.Contains(id);

            return View();
        }
    }
}