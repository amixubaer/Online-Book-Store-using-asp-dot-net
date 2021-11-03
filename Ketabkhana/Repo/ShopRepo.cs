using Ketabkhana.Models.EF;
using Ketabkhana.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ketabkhana.Repo
{
    public class ShopRepo
    {

        static KetabkhanaEntities db;
        static ShopRepo()
        {
            db = new KetabkhanaEntities();
        }


        public static void Add(Shop a, string rpassword)
        {
            if(a.password == rpassword)
            {

                    var customer = (from c in db.Customers
                                    where c.username == a.username
                                    select c).FirstOrDefault();

                    var admin = (from c in db.Admins
                                 where c.username == a.username
                                 select c).FirstOrDefault();

                    var emp = (from c in db.Employees
                               where c.username == a.username
                               select c).FirstOrDefault();

                    var shop = (from c in db.Shops
                                where c.username == a.username
                                select c).FirstOrDefault();

                    if (customer == null && admin == null && emp == null && shop == null)
                    {
                        db.Shops.Add(a);
                        db.SaveChanges();
                    }

            }
        }

        public static ShopModel Get(int id)
        {
            var shop = (from a in db.Shops
                         where a.id == id
                           select a).FirstOrDefault();

            ShopModel sm = new ShopModel()
            {
                id = shop.id,
                shopName = shop.shopName,
                shopAddress = shop.shopAddress,
                username = shop.username,
                email = shop.email,
                password = shop.password
            };

            return sm;
        }

        

        public static ShopModel Profile(string username)
        {
            Shop shop = (from a in db.Shops
                         where a.username == username
                         select a).FirstOrDefault();

            ShopModel sm = new ShopModel()
            {
                id = shop.id,
                shopName = shop.shopName,
                shopAddress = shop.shopAddress,
                username = shop.username,
                email = shop.email,
                password = shop.password
            };

            return sm;
        }


        public static List<ShopModel> AllShops()
        {
            var shops = new List<ShopModel>();


            foreach (var shop in db.Shops)
            {
                ShopModel sm = new ShopModel()
                {
                    id = shop.id,
                    shopName = shop.shopName,
                    shopAddress = shop.shopAddress,
                    username = shop.username,
                    email = shop.email
                };

                shops.Add(sm);
            }
            return shops;
        }





        public static void Edit(ShopModel a)
        {
            Shop shop = (from ad in db.Shops
                         where ad.id == a.id
                         select ad).FirstOrDefault();

            db.Entry(shop).CurrentValues.SetValues(a);
            db.SaveChanges();

        }


        public static void Delete(ShopModel a)
        {
            Shop shop = (from ad in db.Shops
                         where ad.id == a.id
                           select ad).FirstOrDefault();

            db.Shops.Remove(shop);
            db.SaveChanges();

        }

    }
}