using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4_Html_Table.Controllers
{
    public class BaseController : Controller,  IExceptionFilter, IActionFilter
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            Logger.Debug("Method Start" +" ACTION: " + filterContext.ActionDescriptor.ActionName +" CONTROLLER: "+ filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Logger.Debug("Method End" + " ACTION: " + filterContext.ActionDescriptor.ActionName + " CONTROLLER: " + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);
        }


        protected override void OnException(ExceptionContext filterContext)
        {
            //filterContext.
            // filterContext.Controller.ViewBag.ExceptionMessage = "Custom Exception: Message from OnException method.";
            filterContext.ExceptionHandled = true;
            filterContext.Result = this.RedirectToAction("Error", "Home");
        
            base.OnException(filterContext);
            
        
        }  

    }
    //public class CustAuthFilter : AuthorizeAttribute,IExceptionFilter,IActionFilter
    //{
    //    public override void OnAuthorization(AuthorizationContext filterContext)
    //    {
    //        filterContext.Controller.ViewBag.AutherizationMessage = "Custom Authorization: Message from OnAuthorization method.";
    //    }
    //}
}
