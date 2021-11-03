using Ketabkhana.Models.EF;
using Ketabkhana.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ketabkhana.Repo
{
    public class CustomerRepo
    {


        static KetabkhanaEntities db;
        static CustomerRepo()
        {
            db = new KetabkhanaEntities();
        }


        public static void Add(Customer a, string rpassword)
        {
            if (a.password == rpassword)
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

                if(customer== null && admin == null && emp == null && shop ==null)
                {
                    db.Customers.Add(a);
                    db.SaveChanges();
                }

            }

        }

        public static CustomerModel Get(int id)
        {
            var customer = (from a in db.Customers
                           where a.id == id
                           select a).FirstOrDefault();

            CustomerModel cm = new CustomerModel()
            {
                id = customer.id,
                firstName = customer.firstName,
                lastName = customer.lastName,
                gender = customer.gender,
                dob = customer.dob,
                email = customer.email,
                username = customer.username,
                password = customer.password
            };

            return cm;
        }

        public static CustomerModel Profile(string username)
        {
            Customer customer = (from a in db.Customers
                         where a.username == username
                         select a).FirstOrDefault();

            CustomerModel cm = new CustomerModel()
            {
                id = customer.id,
                firstName = customer.firstName,
                lastName = customer.lastName,
                gender = customer.gender,
                dob = customer.dob,
                email = customer.email,
                username = customer.username,
                password = customer.password
            };

            return cm;

        }

        public static List<CustomerModel> AllCustomers()
        {
            var customers = new List<CustomerModel>();

            foreach (var customer in db.Customers)
            {
                CustomerModel cm = new CustomerModel()
                {
                    id = customer.id,
                    firstName = customer.firstName,
                    lastName = customer.lastName,
                    gender = customer.gender,
                    dob = customer.dob,
                    email = customer.email,
                    username = customer.username,
                    password = customer.password
                };

                customers.Add(cm);
            }
            return customers;
        }




        public static void Edit(CustomerModel a)
        {
            Customer customer = (from ad in db.Customers
                                 where ad.id == a.id
                           select ad).FirstOrDefault();

            db.Entry(customer).CurrentValues.SetValues(a);
            db.SaveChanges();

        }


        public static void Delete(CustomerModel a)
        {
            Customer customer = (from ad in db.Customers
                                 where ad.id == a.id
                           select ad).FirstOrDefault();

            db.Customers.Remove(customer);
            db.SaveChanges();

        }


    }
}