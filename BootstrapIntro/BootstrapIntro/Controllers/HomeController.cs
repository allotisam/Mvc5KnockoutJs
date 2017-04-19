using BootstrapIntro.Models;
using BootstrapIntro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapIntro.Controllers
{
    // This route attribute changes default action from Index() to About()
    //[Route("{action=About}")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("About")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route("Contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Basic()
        {
            return View();
        }

        public ActionResult Advanced()
        {
            var person = new Person()
            {
                FirstName = "Eric",
                LastName = "McQuiggan"
            };

            return View(person);
        }
    }
}