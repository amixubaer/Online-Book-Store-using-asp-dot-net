using Ketabkhana.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ketabkhana.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //this.Roles = "Admin";
            var flag = base.AuthorizeCore(httpContext);
            if (flag)
            {
                var username = httpContext.User.Identity.Name;
                //                httpContext.User.Identity.IsAuthenticated
                var db = new KetabkhanaEntities();

                var admin = (from c in db.Admins
                                where c.username == username
                                select c).FirstOrDefault();

                
                if (admin != null) 
                    return true;

            }
            return false;
        }
    }
}