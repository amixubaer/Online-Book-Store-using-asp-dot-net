
using Ketabkhana.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ketabkhana.Repo
{
    public class TransactionRepo
    {
        static KetabkhanaEntities db;
        static TransactionRepo()
        {
            db = new KetabkhanaEntities();
        }

        public static void Add(Transaction t)
        {
            db.Transactions.Add(t);
            db.SaveChanges();

        }

        public static Transaction Get(int id)
        {
            Transaction t = (from tr in db.Transactions
                     where tr.id == id
                     select tr).FirstOrDefault();
            return t;

        }


        public static List<Transaction> AllTransactions()
        {
            var transactions = from t in db.Transactions
                               select t;

            return transactions.ToList();
        }

        public static List<Transaction> ShopTransactions(string username)
        {
            var transactions = from t in db.Transactions
                               where t.shopUsername == username
                               select t;
            return transactions.ToList();
        }

        public static List<Transaction> CustomerTransactions(string username)
        {
            var transactions = from t in db.Transactions
                         where t.customerUsername == username
                         select t;
            return transactions.ToList();
        }



    }
}