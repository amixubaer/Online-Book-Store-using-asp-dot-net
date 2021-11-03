using Ketabkhana.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ketabkhana.Repo
{
    public class AdminRepo
    {
        static KetabkhanaEntities db;
        static AdminRepo()
        {
            db = new KetabkhanaEntities();
        }


        public static void Add(Admin a)
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
                db.Admins.Add(a);
                db.SaveChanges();
            }
            

        }

        public static Admin Get(int id)
        {
            Admin admin = (from a in db.Admins
                             where a.id == id
                             select a).FirstOrDefault();
            return admin;

        }

        public static Admin Profile(string username)
        {
            Admin admin = (from a in db.Admins
                         where a.username == username
                         select a).FirstOrDefault();
            return admin;

        }

        public static List<Admin> AllAdmins()
        {
            var admins = from a in db.Admins
                               select a;

            return admins.ToList();
        }

        public static void Edit(Admin a)
        {
            Admin admin = (from ad in db.Admins
                            where ad.id == a.id
                            select ad).FirstOrDefault();

            db.Entry(admin).CurrentValues.SetValues(a);
            db.SaveChanges();

        }


        public static void Delete(Admin a)
        {
            Admin admin = (from ad in db.Admins
                           where ad.id == a.id
                           select ad).FirstOrDefault();

            db.Admins.Remove(admin);
            db.SaveChanges();

        }



    }
}