using Ketabkhana.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ketabkhana.Repo
{
    public class SalaryRepo
    {
        static KetabkhanaEntities db;
        static SalaryRepo()
        {
            db = new KetabkhanaEntities();
        }


        public static List<Salary> AllSalaries()
        {
            var salaries = from a in db.Salaries
                           select a;

            return salaries.ToList();
        }
    }
}