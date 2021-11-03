using Ketabkhana.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ketabkhana.Repo
{
    public class SupportRepo
    {

        static KetabkhanaEntities db;
        static SupportRepo()
        {
            db = new KetabkhanaEntities();
        }


        public static void Add(Support a)
        {
            db.Supports.Add(a);
            db.SaveChanges();

        }

        public static List<Support> AllSupports()
        {
            var supports = from a in db.Supports
                           select a;

            return supports.ToList();
        }

    }
}