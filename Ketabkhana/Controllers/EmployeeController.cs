using Ketabkhana.Auth;
using Ketabkhana.Models.EF;
using Ketabkhana.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ketabkhana.Controllers
{
    [EmployeeAccess]
    public class EmployeeController : Controller
    {
        // GET: Employee


        public ActionResult AddApproval()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddApproval(Approval a)
        {
            if (ModelState.IsValid)
            {
                ApprovalRepo.Add(a);
                return RedirectToAction("AllSalaries");

            }
            return View();

        }

        public ActionResult AllSalaries()
        {
            var s = SalaryRepo.AllSalaries();
            return View(s);
        }



        /// <summary>
        /// #######################################################################
        /// </summary>
        /// <returns></returns>


        public ActionResult AllOrders()
        {
            var a = OrderRepo.AllOrders();
            return View(a);
        }

        public ActionResult OrdersDetails(int id)
        {
            var a = OrderDetailRepo.Get(id);
            return View(a);
        }


        /// <summary>
        /// #######################################################################
        /// </summary>
        /// <returns></returns>



        public ActionResult AddTransaction()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTransaction(Transaction t)
        {
            if (ModelState.IsValid)
            {
                TransactionRepo.Add(t);
                return RedirectToAction("AllTransactions");
            }
            return View();

        }

        public ActionResult AllTransactions()
        {
            var t = TransactionRepo.AllTransactions();
            return View(t);
        }


        /// <summary>
        /// #######################################################################
        /// </summary>
        /// <returns></returns>


        public ActionResult AddStatement()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStatement(Statement s)
        {
            if (ModelState.IsValid)
            {
                StatementRepo.Add(s);
                return RedirectToAction("AllStatements");
            }

            return View();
        }


        public ActionResult AllStatements()
        {
            var s = StatementRepo.AllStatements();
            return View(s);
        }

        /// <summary>
        /// #######################################################################
        /// </summary>
        /// <returns></returns>


        public ActionResult AddSupport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSupport(Support s)
        {
            if (ModelState.IsValid)
            {
                SupportRepo.Add(s);
                return View();
            }
            return View();

        }

        /// <summary>
        /// #######################################################################
        /// </summary>
        /// <returns></returns>


        public ActionResult MyProfile()
        {
            string username = User.Identity.Name;
            var e = EmployeeRepo.Profile(username);
            return View(e);
        }

        [HttpPost]
        public ActionResult MyProfile(Employee e)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form["Edit"] != null)
                {
                    EmployeeRepo.Edit(e);

                    //return View(e);
                }
                else if (Request.Form["Delete"] != null)
                {
                    EmployeeRepo.Delete(e);
                    Session.Abandon();
                    return RedirectToAction("Login", "Home");
                }

                return View(e);
            }

            return View(e);

        }





    }
}