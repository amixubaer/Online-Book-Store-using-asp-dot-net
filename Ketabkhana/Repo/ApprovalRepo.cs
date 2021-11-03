using Ketabkhana.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ketabkhana.Repo
{
    public class ApprovalRepo
    {
        static KetabkhanaEntities db;
        static ApprovalRepo()
        {
            db = new KetabkhanaEntities();
        }


        public static void Add(Approval a)
        {
            db.Approvals.Add(a);
            db.SaveChanges();
        }


        public static Approval Get(int id)
        {
            var approval = (from a in db.Approvals
                        where a.id == id
                        select a).FirstOrDefault();


            return approval;


        }



        public static List<Approval> AllApprovals()
        {
            var approvals = from a in db.Approvals
                            select a;

            return approvals.ToList();
        }


        public static void Approve(int id)
        {
            Approval approval = (from ad in db.Approvals
                                 where ad.id == id
                                 select ad).FirstOrDefault();

            db.Approvals.Remove(approval);
            db.SaveChanges();

            Salary s = new Salary
            {
                employeeUsername = approval.employeeUsername,
                salary1 = approval.salary,
                bonus = approval.bonus
            };

            db.Salaries.Add(s);
            db.SaveChanges();
        }


        public static void Decline(int id)
        {
            Approval approval = (from ad in db.Approvals
                                 where ad.id == id
                                 select ad).FirstOrDefault();

            db.Approvals.Remove(approval);
            db.SaveChanges();

        }
    }
}