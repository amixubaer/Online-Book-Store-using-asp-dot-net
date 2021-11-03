using Ketabkhana.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ketabkhana.Repo
{
    public class EmployeeRepo
    {

        static KetabkhanaEntities db;
        static EmployeeRepo()
        {
            db = new KetabkhanaEntities();
        }


        public static void Add(Employee a)
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
                db.Employees.Add(a);
                db.SaveChanges();
            }

        }

        public static Employee Get(int id)
        {
            Employee employee = (from a in db.Employees
                                 where a.id == id
                            select a).FirstOrDefault();
            return employee;

        }

        public static Employee Profile(string username)
        {
            Employee employee = (from a in db.Employees
                         where a.username == username
                         select a).FirstOrDefault();
            return employee;

        }

        public static List<Employee> AllEmployees()
        {
            var employees = from a in db.Employees
                            select a;

            return employees.ToList();
        }

        public static void Edit(Employee a)
        {
            var employee = (from ad in db.Employees
                                 where ad.id == a.id
                                 select ad).FirstOrDefault();

            //employee.firstName = a.firstName;
            //employee.lastName = a.lastName;
            //employee.gender = a.gender;
            //employee.dob = a.dob;
            //employee.email = a.email;
            //employee.password = a.password;

            db.Entry(employee).CurrentValues.SetValues(a);
            db.SaveChanges();

        }


        public static void Delete(Employee a)
        {
            Employee employee = (from ad in db.Employees
                                 where ad.id == a.id
                           select ad).FirstOrDefault();

            db.Employees.Remove(employee);
            db.SaveChanges();

        }

    }
}