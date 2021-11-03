using Ketabkhana.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ketabkhana.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomerAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //this.Roles = "Customer";

            var flag = base.AuthorizeCore(httpContext);
            if (flag)
            {
                var username = httpContext.User.Identity.Name;
                //                httpContext.User.Identity.IsAuthenticated
                var db = new KetabkhanaEntities();

                var cus = (from c in db.Customers
                            where c.username == username
                            select c).FirstOrDefault();


                if (cus != null)
                {
                    //this.Roles = "Customer";
                    return true;
                }
                    

            }
            return false;
        }
    }
}