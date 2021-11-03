using Ketabkhana.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ketabkhana.Repo
{
    public class StatementRepo
    {

        static KetabkhanaEntities db;
        static StatementRepo()
        {
            db = new KetabkhanaEntities();
        }


        public static void Add(Statement a)
        {
            db.Statements.Add(a);
            db.SaveChanges();

        }

        public static List<Statement> AllStatements()
        {
            var statements = from a in db.Statements
                             select a;

            return statements.ToList();
        }

    }
}