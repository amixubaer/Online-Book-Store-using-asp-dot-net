using Ketabkhana.Auth;
using Ketabkhana.Models.EF;
using Ketabkhana.Models.VM;
using Ketabkhana.Repo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ketabkhana.Controllers
{
    [ShopAccess]
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            var b = BookRepo.AllBooks();
            return View(b);
        }

        /// <summary>
        /// ###############################################################################
        /// </summary>
        /// <returns></returns>

        public ActionResult MyBooks()
        {
            string username = User.Identity.Name;
            var b = BookRepo.MyBooks(username);
            return View(b);
        }




        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(HttpPostedFileBase file, Book b)
        {
            if (ModelState.IsValid)
            {
                string username = User.Identity.Name;

                var db = new KetabkhanaEntities();
                var shop = (from a in db.Shops
                            where a.username == username
                            select a).FirstOrDefault();

                string filename = Path.GetFileName(file.FileName);
                string _filename = DateTime.Now.ToString("yymmssff") + filename;
                string extension = Path.GetExtension(file.FileName);
                string path = Path.Combine(Server.MapPath("~/images/"), _filename);
                b.thumbnail = _filename;
                b.shopId = shop.id;

                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                {

                    db.Books.Add(b);
                    db.SaveChanges();
                    file.SaveAs(path);
                    ModelState.Clear();

                }

                //string username = User.Identity.Name;;
                //BookRepo.Add(b, username);
                return RedirectToAction("MyBooks");
            }

            return View();
        }





        public ActionResult EditBook(int id)
        {
            var e = BookRepo.Get(id);
            return View(e);
        }

        [HttpPost]
        public ActionResult EditBook(Book b)
        {
            if (ModelState.IsValid)
            {
                BookRepo.Edit(b);
                return RedirectToAction("MyBooks");
            }

            return View(b);
        }
        



        public ActionResult DeleteBook(int id)
        {
            var e = BookRepo.Get(id);
            return View(e);
        }

        [HttpPost]
        public ActionResult DeleteBook(Book b)
        {

            BookRepo.Delete(b);
            return RedirectToAction("MyBooks");
        }


        /// <summary>
        /// ###############################################################################
        /// </summary>
        /// <returns></returns>



        public ActionResult MyOrders()
        {
            string username = User.Identity.Name;

            var a = OrderDetailRepo.MyOrders(username);
            return View(a);
        }


        /// <summary>
        /// ###############################################################################
        /// </summary>
        /// <returns></returns>



        public ActionResult ShopTransactions()
        {
            string username = User.Identity.Name;
            var t = TransactionRepo.ShopTransactions(username);
            return View(t);
        }


        /// <summary>
        /// ###############################################################################
        /// </summary>
        /// <returns></returns>



        public ActionResult MyProfile()
        {
            string username = User.Identity.Name;
            var e = ShopRepo.Profile(username);
            return View(e);
        }

        [HttpPost]
        public ActionResult MyProfile(ShopModel s)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form["Edit"] != null)
                {
                    ShopRepo.Edit(s);

                    //return View(e);
                }
                else if (Request.Form["Delete"] != null)
                {
                    ShopRepo.Delete(s);
                    Session.Abandon();
                    return RedirectToAction("Login", "Home");
                }

                return View(s);
            }
            return View(s);

        }


        /// <summary>
        /// ###############################################################################
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


    }
}