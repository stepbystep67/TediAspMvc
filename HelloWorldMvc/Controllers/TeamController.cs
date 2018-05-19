using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorldMvc.Models;

namespace HelloWorldMvc.Controllers
{
    public class TeamController : Controller
    {

        // GET: Staff
        public ActionResult Index()
        {
            return View(PersonManager.TeamMembers);
        }

        // GET: Staff/Details
        public ActionResult Details(int id)
        {
            Person person = PersonManager.Search(id);

            return View(person);
        }
    }
}