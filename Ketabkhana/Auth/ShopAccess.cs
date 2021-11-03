using Ketabkhana.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ketabkhana.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ShopAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //this.Roles = "Shop";

            var flag = base.AuthorizeCore(httpContext);
            if (flag)
            {
                var username = httpContext.User.Identity.Name;
                //                httpContext.User.Identity.IsAuthenticated
                var db = new KetabkhanaEntities();

                var shop = (from c in db.Shops
                           where c.username == username
                           select c).FirstOrDefault();


                if (shop != null)
                    return true;

            }
            return false;
        }
    }
}