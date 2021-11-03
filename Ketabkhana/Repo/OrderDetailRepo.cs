using Ketabkhana.Models.EF;
using Ketabkhana.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ketabkhana.Repo
{
    public class OrderDetailRepo
    {

        static KetabkhanaEntities db;
        static OrderDetailRepo()
        {
            db = new KetabkhanaEntities();
        }


        public static List<OrderDetailModel> Get(int id)
        {

            var lodm = new List<OrderDetailModel>();

            var orderDetails = from od in db.OrderDetails
                               where od.orderId == id
                               select od;
            

            foreach (var o in orderDetails)
            {
                var odm = new OrderDetailModel()
                {
                    id = o.id,
                    bookId = o.bookId,
                    orderId = o.orderId,
                    shopId = o.shopId,
                    unitPrice = o.unitPrice,
                    quantity = o.quantity

                };

                lodm.Add(odm);

            }

            return lodm.ToList();

        }


        public static List<OrderDetailModel> MyOrders(string username)
        {
            Shop shop= (from s in db.Shops
                        where s.username == username
                        select s).FirstOrDefault();

            var orderDetails = from e in db.OrderDetails
                               where e.shopId == shop.id
                               select e;

            var lodm = new List<OrderDetailModel>();

            foreach (var o in orderDetails)
            {
                var odm = new OrderDetailModel()
                {
                    id = o.id,
                    bookId = o.bookId,
                    orderId = o.orderId,
                    shopId = o.shopId,
                    unitPrice = o.unitPrice,
                    quantity = o.quantity

                };

                lodm.Add(odm);

            }

            return lodm.ToList();
        }
    }
}