using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIMS.Helper
{
    public class FcAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext != null &&
                (filterContext.HttpContext.Session == null || filterContext.HttpContext.Session["UserId"] == null))
                filterContext.Result = new RedirectResult("~/Account/Login");
        }
    }  
}