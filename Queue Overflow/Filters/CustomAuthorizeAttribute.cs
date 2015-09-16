using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace QueueOverflow.Filters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly ILog _Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            _Logger.Info("Method start");
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (HttpContext.Current.Request.Cookies["MXAuthCookie"] == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                filterContext.RequestContext.HttpContext.Response.Redirect("~/home/Login", true);
            }

            _Logger.Info("Method end");
        }


    }
}