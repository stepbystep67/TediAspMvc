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

        public TeamController()
        {
            PersonManager.Load();
        }

        // GET: Team
        public ActionResult Index()
        {
            return View(PersonManager.DefaultPersonList);
        }

        // GET: Team/Details/{id}
        public ActionResult Details(int id)
        {
            Person person = PersonManager.Search(id);

            return View(person);
        }

        // GET: Team/Member/{name}
        public ActionResult Member(string id)
        {
            Person person = PersonManager.Search(id);

            return View("Details", person);
        }

        // GET: Team/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Team/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Person formResult)
        {
            if (formResult.IsValid())
            {
                formResult.Id = (PersonManager.DefaultPersonList.Max(p => p.Id) + 1);
                PersonManager.DefaultPersonList.Add(formResult);
                PersonManager.Save();
                return RedirectToAction("Index");
            }

            return View(formResult);
        }

        // GET: Team/Edit/{id}
        public ActionResult Edit(int id)
        {
            Person person = PersonManager.Search(id);

            return View(person);
        }

        // POST: Team/Edit/{id}
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Person formResult)
        {
            Person person = PersonManager.Search(formResult);

            if(formResult.IsValid() && person.IsRegistered())
            {
                person.Name = formResult.Name;
                person.Job = formResult.Job;
                PersonManager.Save();
                return RedirectToAction("Index");
            }

            return View(formResult);
        }

        // GET: Team/Delete/{id}
        public ActionResult Delete(int id)
        {
            Person person = PersonManager.Search(id);

            return View(person);
        }

        // POST: Team/Delete/{id}
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(Person formResult)
        {
            Person person = PersonManager.Search(formResult);

            if (person.IsRegistered())
            {
                PersonManager.DefaultPersonList.Remove(person);
                PersonManager.Save();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Delete", new { id = formResult.Id });
        }
    }
}