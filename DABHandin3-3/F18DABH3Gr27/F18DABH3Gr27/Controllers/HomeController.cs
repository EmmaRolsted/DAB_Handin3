using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F18DABH3Gr27.Repository;
using F18DABH3Gr27.Models;

namespace F18DABH3Gr27.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //var uow = new UnitOfWork<Person>().InitializeDataBase();
            return View();
        }
    }
}
