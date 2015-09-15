using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace MVC4_Html_Table.Filters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly ILog _Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            _Logger.Debug("OnAuthorization start");
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (HttpContext.Current.Request.Cookies["MXGourav"] != null)
            {
                _Logger.Debug("OnAuthorization MXGourav");
               // base.OnAuthorization(filterContext);


            }
            else
            {
                _Logger.Debug("OnAuthorization else part");
                filterContext.Result = new HttpUnauthorizedResult();
                filterContext.RequestContext.HttpContext.Response.Redirect("~/home/Login", true);

            }


        }


    }
}