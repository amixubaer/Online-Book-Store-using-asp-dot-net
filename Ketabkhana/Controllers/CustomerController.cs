using Ketabkhana.Auth;
using Ketabkhana.Models.EF;
using Ketabkhana.Models.VM;
using Ketabkhana.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Ketabkhana.Controllers
{
    [CustomerAccess]
    public class CustomerController : Controller
    {

        // GET: Customer
        public ActionResult Index()
        {
            var b = BookRepo.AllBooks();
            return View(b);
        }

        [HttpPost]
        public ActionResult Index(string bt)
        {
            var src = BookRepo.SrcBooks(bt);
            return View(src);
        }

        /// <summary>
        /// #######################################################################
        /// </summary>
        /// <returns></returns>

        public ActionResult Payment()
        {
            return View();
        }

        /// <summary>
        /// #######################################################################
        /// </summary>
        /// <returns></returns>

        public ActionResult CustomerTransactions()
        {
            string username = User.Identity.Name;
            var t = TransactionRepo.CustomerTransactions(username);
            return View(t);
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
            var e = CustomerRepo.Profile(username);
            return View(e);
        }

        [HttpPost]
        public ActionResult MyProfile(CustomerModel c)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form["Edit"] != null)
                {
                    CustomerRepo.Edit(c);

                    return RedirectToAction("Index");
                }
                else if (Request.Form["Delete"] != null)
                {
                    CustomerRepo.Delete(c);
                    Session.Abandon();
                    return RedirectToAction("Login", "Home");
                }

                return View(c);
            }

            return View(c);

        }


        /// <summary>
        /// #######################################################################
        /// </summary>
        /// <returns></returns>


        public ActionResult AddtoCart(int id)
        {
            var book = BookRepo.Get(id);
            BookModel bm = new BookModel()
            {
                id = book.id,
                bookTitle = book.bookTitle,
                author = book.author,
                publisher = book.publisher,
                edition = book.edition,
                price = book.price,
                shopId = book.shopId,
                quantity = book.quantity,
                thumbnail = book.thumbnail
            };

            bm.quantity = 1;
            List<BookModel> books;
            if (Session["cart"] == null)
            {
                books = new List<BookModel>();
                books.Add(bm);
            }

            else
            {
                var json = Session["cart"].ToString();
                books = new JavaScriptSerializer().Deserialize<List<BookModel>>(json);

                foreach (BookModel b in books)
                {
                    if (b.id == id)
                    {
                        b.quantity += 1;

                        var json3 = new JavaScriptSerializer().Serialize(books);
                        Session["cart"] = json3;
                        return RedirectToAction("Index");
                    }
                        
                    
                }

                books.Add(bm);


            }

            var json2 = new JavaScriptSerializer().Serialize(books);

            Session["cart"] = json2;
            return RedirectToAction("Index");

        }


        public ActionResult PlusCart(int id)
        {


            List<BookModel> books;

            var json = Session["cart"].ToString();
            books = new JavaScriptSerializer().Deserialize<List<BookModel>>(json);

            foreach (BookModel b in books)
            {
                if (b.id == id)
                {
                    b.quantity += 1;

                    var json2 = new JavaScriptSerializer().Serialize(books);
                    Session["cart"] = json2;
                }


            }
            return RedirectToAction("Cart");

        }

        public ActionResult MinusCart(int id)
        {


            List<BookModel> books;
            List<BookModel> books2;

            var json = Session["cart"].ToString();
            books = new JavaScriptSerializer().Deserialize<List<BookModel>>(json);

            foreach (BookModel b in books)
            {
                if (b.id == id)
                {
                    b.quantity -= 1;

                    if(b.quantity<=0)
                    {
                        books2 = new List<BookModel>();
                        foreach (var book in books)
                        {
                            if (book.id != id)
                                books2.Add(book);
                        }


                        var json3 = new JavaScriptSerializer().Serialize(books2);

                        Session["cart"] = json3;
                        return RedirectToAction("Cart");
                    }

                    var json2 = new JavaScriptSerializer().Serialize(books);
                    Session["cart"] = json2;
                    
                    
                }


            }
            return RedirectToAction("Cart");

        }


        public ActionResult DeleteFromCart(int id)
        {
            var bm = BookRepo.Get(id);
            List<BookModel> books;
            List<BookModel> books2;

            var json = Session["cart"].ToString();
            books = new JavaScriptSerializer().Deserialize<List<BookModel>>(json);

            books2 = new List<BookModel>();
            foreach (var b in books)
            {
                if(b.id != id)
                    books2.Add(b);
            }


            //books.Remove(bm);

            var json2 = new JavaScriptSerializer().Serialize(books2);

            Session["cart"] = json2;
            return RedirectToAction("Cart");

        }



        public ActionResult ClearCart()
        {
            List<BookModel> books;

            var json = Session["cart"].ToString();
            books = new JavaScriptSerializer().Deserialize<List<BookModel>>(json);

            books.Clear();

            var json2 = new JavaScriptSerializer().Serialize(books);

            Session["cart"] = json2;
            return RedirectToAction("Cart");

        }




        public ActionResult Cart()
        {
            if(Session["cart"] != null)
            {
                var json = Session["cart"].ToString();
                var books = new JavaScriptSerializer().Deserialize<List<BookModel>>(json);
                return View(books);
            }
            return RedirectToAction("Index");
        }




        public ActionResult Checkout()
        {
            var json = Session["cart"].ToString();
            var books = new JavaScriptSerializer().Deserialize<List<BookModel>>(json);

            var username = User.Identity.Name;
            OrderRepo.PlaceOrder(books, username);
            Session.Remove("cart");
            return RedirectToAction("Index");


        }
        public ActionResult MyOrders()
        {
            var username = User.Identity.Name;
            var orders = OrderRepo.MyOrders(username);
            return View(orders);

        }

        public ActionResult OrdersDetails(int id)
        {
            var a = OrderDetailRepo.Get(id);
            return View(a);
        }

    }
}