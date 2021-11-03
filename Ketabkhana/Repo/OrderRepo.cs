using Ketabkhana.Models.EF;
using Ketabkhana.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ketabkhana.Repo
{
    public class OrderRepo
    {
        static KetabkhanaEntities db;
        static OrderRepo()
        {
            db = new KetabkhanaEntities();
        }
        public static void PlaceOrder(List<BookModel> books, string username)
        {

            var c = (from cus in db.Customers
                     where cus.username == username
                     select cus).FirstOrDefault();

            var x = 0.0;

            foreach (var p in books)
            {
                x += (float)p.price*p.quantity;
            }


            Order o = new Order();
            o.amount = x;
            o.status = "Ordered";
            o.customerId = c.id;
            
            db.Orders.Add(o);
            db.SaveChanges();

            foreach (var b in books)
            {
                var od = new OrderDetail()
                {
                    orderId = o.id,
                    bookId = b.id,
                    unitPrice = b.price,
                    quantity = b.quantity,
                    shopId = b.shopId
                };
                db.OrderDetails.Add(od);
                db.SaveChanges();


                var book = (from bo in db.Books
                            where bo.id == b.id
                            select bo).FirstOrDefault();


                book.quantity -= b.quantity;
                db.SaveChanges();

            }
        }

        public static List<Order> MyOrders(string username)
        {
            Customer customer = (from a in db.Customers
                                 where a.username == username
                                 select a).FirstOrDefault();

            var orders = from e in db.Orders
                         where e.customerId == customer.id
                         select e;
            return orders.ToList();
        }

        public static List<Order> AllOrders()
        {
            var orders = from e in db.Orders
                         select e;
            return orders.ToList();
        }
    }
}