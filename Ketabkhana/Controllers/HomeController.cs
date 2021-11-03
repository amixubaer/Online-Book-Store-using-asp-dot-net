using Ketabkhana.Models.EF;
using Ketabkhana.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ketabkhana.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var b = BookRepo.AllBooks();
            return View(b);
        }


        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
           
            var db = new KetabkhanaEntities();

            var customer = (from cu in db.Customers
                            where cu.username == username
                            where cu.password == password
                            select cu).FirstOrDefault();

            var shop = (from cu in db.Shops
                        where cu.username == username
                        where cu.password == password
                        select cu).FirstOrDefault();

            var employee = (from cu in db.Employees
                            where cu.username == username
                            where cu.password == password
                            select cu).FirstOrDefault();

            var admin = (from cu in db.Admins
                            where cu.username == username
                         where cu.password == password
                         select cu).FirstOrDefault();
            if (customer != null)
            {
                FormsAuthentication.SetAuthCookie(customer.username, true);
                Session["role"] = "Customer";
                return RedirectToAction("Index", "Customer");
            }

            else if (shop != null)
            {
                FormsAuthentication.SetAuthCookie(shop.username, true);
                Session["role"] = "Shop";
                return RedirectToAction("Index", "Shop");
            }

            else if (employee != null)
            {
                FormsAuthentication.SetAuthCookie(employee.username, true);
                Session["role"] = "Employee";
                return RedirectToAction("AllOrders", "Employee");
            }

            else if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.username, true);
                Session["role"] = "Admin";
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

       
        



        public ActionResult Logout()
        {
            Session.Remove("role");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


    }
}