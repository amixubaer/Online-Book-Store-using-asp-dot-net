using Ketabkhana.Auth;
using Ketabkhana.Models.EF;
using Ketabkhana.Models.VM;
using Ketabkhana.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ketabkhana.Controllers
{
    [AdminAccess]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            var b = BookRepo.AllBooks();
            return View(b);
        }


        /// <summary>
        /// ###############################################################################
        /// </summary>
        /// <returns></returns>



        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin a)
        {
            if (ModelState.IsValid)
            {
                AdminRepo.Add(a);
                return RedirectToAction("AllAdmins");
            }
            return View();
        }

        public ActionResult AllAdmins()
        {
            var a = AdminRepo.AllAdmins();
            return View(a);
        }

        public ActionResult UpdateAdmin(int id)
        {
            var a = AdminRepo.Get(id);
            return View(a);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin a)
        {
            if (ModelState.IsValid)
            {
                AdminRepo.Edit(a);
                return RedirectToAction("AllAdmins");
            }
            return View(a);
        }


        public ActionResult DeleteAdmin(int id)
        {
            var a = AdminRepo.Get(id);
            return View(a);
        }

        [HttpPost]
        public ActionResult DeleteAdmin(Admin a)
        {
            AdminRepo.Delete(a);
            return RedirectToAction("AllAdmins");
        }



        /// <summary>
        /// #########################################################################
        /// </summary>
        /// <returns></returns>


        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee e)
        {
            if (ModelState.IsValid)
            {
                EmployeeRepo.Add(e);
                return RedirectToAction("AllEmployees");
            }
            return View();
        }



        public ActionResult AllEmployees()
        {
            var a = EmployeeRepo.AllEmployees();
            return View(a);
        }



        public ActionResult UpdateEmployee(int id)
        {
          
            var a = EmployeeRepo.Get(id);
            return View(a);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee e)
        {
            if (ModelState.IsValid)
            {
                EmployeeRepo.Edit(e);
                return RedirectToAction("AllEmployees");
            }
            return View(e);
        }





        public ActionResult DeleteEmployee(int id)
        {
            var a = EmployeeRepo.Get(id);
            return View(a);
        }

        [HttpPost]
        public ActionResult DeleteEmployee(Employee e)
        {
            EmployeeRepo.Delete(e);
            return RedirectToAction("AllEmployees");
        }


        /// <summary>
        /// ##########################################################################
        /// </summary>
        /// <returns></returns>






        public ActionResult AllShops()
        {
            var a = ShopRepo.AllShops();
            return View(a);
        }



        public ActionResult UpdateShop(int id)
        {
            var a = ShopRepo.Get(id);
            return View(a);
        }

        [HttpPost]
        public ActionResult UpdateShop(ShopModel s)
        {
            if (ModelState.IsValid)
            {
                ShopRepo.Edit(s);
                return RedirectToAction("AllShops");
            }
            return View(s);
        }



        public ActionResult DeleteShop(int id)
        {
            var a = ShopRepo.Get(id);
            return View(a);
        }

        [HttpPost]
        public ActionResult DeleteShop(ShopModel s)
        {
            ShopRepo.Delete(s);
            return RedirectToAction("AllShops");
        }



        /// <summary>
        /// #######################################################################################
        /// </summary>
        /// <returns></returns>




        public ActionResult AllCustomers()
        {
            var a = CustomerRepo.AllCustomers();
            return View(a);
        }



        public ActionResult UpdateCustomer(int id)
        {
            var a = CustomerRepo.Get(id);
            return View(a);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(CustomerModel c)
        {
            if (ModelState.IsValid)
            {
                CustomerRepo.Edit(c);
                return RedirectToAction("AllCustomers");
            }
            return View(c);

        }




        public ActionResult DeleteCustomer(int id)
        {
            var a = CustomerRepo.Get(id);
            return View(a);
        }

        [HttpPost]
        public ActionResult DeleteCustomer(CustomerModel c)
        {
            CustomerRepo.Delete(c);
            return RedirectToAction("AllCustomers");
        }


        /// <summary>
        /// #####################################################################################
        /// </summary>
        /// <returns></returns>



        public ActionResult AllStatements()
        {
            var a = StatementRepo.AllStatements();
            return View(a);
        }



        public ActionResult AllTransactions()
        {
            var a = TransactionRepo.AllTransactions();
            return View(a);
        }




        public ActionResult AllApprovals()
        {
            var a = ApprovalRepo.AllApprovals();
            return View(a);
        }

        public ActionResult ApproveApproval(int id)
        {
            var a = ApprovalRepo.Get(id);
            return View(a);
        }

        [HttpPost]
        public ActionResult ApproveApproval(Approval a)
        {
            ApprovalRepo.Approve(a.id);
            return RedirectToAction("AllApprovals");
        }


        public ActionResult DeclineApproval(int id)
        {
            var a = ApprovalRepo.Get(id);
            return View(a);
        }

        [HttpPost]
        public ActionResult DeclineApproval(Approval a)
        {
            ApprovalRepo.Decline(a.id);
            return RedirectToAction("AllApprovals");
        }




        public ActionResult AllSalaries()
        {
            var a = SalaryRepo.AllSalaries();
            return View(a);
        }



        /// <summary>
        /// #############################################################################################
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
        /// ###################################################################################################
        /// </summary>
        /// <returns></returns>

        public ActionResult AllSupports()
        {
            var a = SupportRepo.AllSupports();
            return View(a);
        }


        /// <summary>
        /// ###################################################################################################
        /// </summary>
        /// <returns></returns>


        public ActionResult MyProfile()
        {
            string username = User.Identity.Name;
            var e = AdminRepo.Profile(username);
            return View(e);
        }

        [HttpPost]
        public ActionResult MyProfile(Admin a)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form["Edit"] != null)
                {
                    AdminRepo.Edit(a);

                    //return View(e);
                }
                else if (Request.Form["Delete"] != null)
                {
                    AdminRepo.Delete(a);

                    Session.Abandon();
                    return RedirectToAction("Login", "Home");
                }

                return View(a);
            }

            return View(a);

        }


    }
}