using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldMvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Bonjour !";
        }

        // GET: Home/Hello
        public string Hello()
        {
            return "Bonjour ASP.NET MVC !";
        }

        // GET: Home/Secret
        public string Secret(string id)
        {
            if (id != "lebonmotdepasse")
            {
                return "Code incorrect !";
            }
            
            return "Bravo !";
        }

        // GET: Home/Tva
        public string Tva(int? id)
        {
            int ht = (id != null) ? (int)id : 1;

            double ttc = (ht * 1.2);
            
            return (ht.ToString() + "€ (HT) = " + ttc.ToString("####.##") + " € TTC");
        }

        
    }
}