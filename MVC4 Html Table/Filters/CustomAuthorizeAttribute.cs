using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4_Html_Table.Filters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (HttpContext.Current.Request.Cookies["MXGourav"] != null)
            {
                base.OnAuthorization(filterContext);


            }
            else
            {
                filterContext.Result = new HttpUnauthorizedResult();
                filterContext.RequestContext.HttpContext.Response.Redirect("~/home/Login", true);

            }


        }


    }
}