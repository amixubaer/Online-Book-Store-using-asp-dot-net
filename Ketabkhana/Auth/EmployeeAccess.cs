using Ketabkhana.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ketabkhana.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class EmployeeAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //this.Roles = "Employee";

            var flag = base.AuthorizeCore(httpContext);
            if (flag)
            {
                var username = httpContext.User.Identity.Name;
                //                httpContext.User.Identity.IsAuthenticated
                var db = new KetabkhanaEntities();

                var emp = (from c in db.Employees
                             where c.username == username
                             select c).FirstOrDefault();


                if (emp!= null)
                    return true;

            }
            return false;
        }
    }
}