using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4_Html_Table.Controllers
{
    public class BaseController : Controller,  IExceptionFilter, IActionFilter
    {
        private static readonly log4net.ILog _Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region OnActionExecuting
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _Logger.Info("Method Start" +" ACTION: " + filterContext.ActionDescriptor.ActionName +" CONTROLLER: "+ filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);
            base.OnActionExecuting(filterContext);
        }
        #endregion

        #region OnActionExecuted
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _Logger.Info("Method End" + " ACTION: " + filterContext.ActionDescriptor.ActionName + " CONTROLLER: " + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);
        }
        #endregion

        

    }

    
}
