using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4_Html_Table.Filters
{
    public class CustomAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Request.Cookies["MXGourav"] == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }

        }


    }
}