using Ketabkhana.Models.EF;
using Ketabkhana.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ketabkhana.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Customer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Customer(Customer a, string rpassword)
        {
            if (ModelState.IsValid)
            {
                CustomerRepo.Add(a, rpassword);
                return View(a);
            }
            return View();

        }

        public ActionResult Shop()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Shop(Shop a,string rpassword)
        {

            if (ModelState.IsValid)
            {
                ShopRepo.Add(a,rpassword);
                return View(a);

            }
            return View();

        }
    }
}