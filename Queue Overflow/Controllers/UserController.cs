using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QueueOverflow.Models;
using RestService;
using Newtonsoft.Json;
using log4net;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using Utilities;
using System.Configuration;
using QueueOverflow.Filters;
using System.Web.Services;
using System.Web.Security;
using QueueOverflow.Libraries;
namespace QueueOverflow.Controllers
{
    [CustomAuthorize]
    public class UserController : BaseController
    {
        private readonly ILog _Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string BaseURL = ConfigurationManager.AppSettings["UserServiceURL"].ToString();


        #region Dashboard
        [ValidateInput(false)]  
        public ActionResult Dashboard() 
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get("MXAuthCookie");
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            string UserData = ticket.UserData;
            User User = JsonConvert.DeserializeObject<User>(UserData);
            ViewBag.UserName = User.UserName;
            ViewBag.FullName = User.FullName;
            ViewBag.Phone = User.Phone;
            ViewBag.Email = User.Email;
            ViewBag.City = User.City;
            ViewBag.Dob = User.Dob;
            return View();
        }
        #endregion  

        #region Index
        [ValidateInput(false)]
        public ActionResult Index()
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get("MXAuthCookie");
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            string UserData = ticket.UserData;
            User User = SigninManagement.GetAuthCookieData();
            if (User.UserName != "admin")
            {
                return RedirectToAction("Dashboard", "User");
            }

            string URL = BaseURL + "Retrieve";
            _Logger.Debug("URL = " + URL);
            try
            {
                string ResponseFromServer = ServiceConsumer.Get(URL);
                _Logger.Debug("ResponseFromServer = " + ResponseFromServer);

                List<User> UsersList = JsonConvert.DeserializeObject<List<User>>(ResponseFromServer);
                if (UsersList!=null && UsersList .Count >0)
                {
                   
                    UsersList.RemoveAll(x => x.UserName == "admin");
                }
                string JsonUser = JsonConvert.SerializeObject(UsersList);
                _Logger.Debug("JsonUser = " + JsonUser);
                ViewData["UserData"] = UsersList;
            }

            catch (Exception exception)
            {
                _Logger.Error(exception.Message, exception);
                throw exception;
            }

            return View();
        }
        #endregion

        #region CreateUser
        [WebMethod]
        public JsonResult CreateUser(User objUser)
        {
            _Logger.Info("Method Start");

            string URL = BaseURL + "Create";
            _Logger.Debug("URL = " + URL);

            objUser.UserId = Guid.NewGuid().ToString();
            try
            {
                LogHelper.LogMaker(objUser);
                string ResponseFromServer = ServiceConsumer.Post(URL, objUser);
                _Logger.Debug("ResponseFromServer = " + ResponseFromServer);

            }

            catch (Exception exception)
            {
                _Logger.Error(exception.Message, exception);
                var ErrorDetail = JObject.Parse(exception.Message)["ErrorDetail"].ToString();
                return Json(new { Status = ErrorDetail });
            }

            _Logger.Info("Method End");
            return Json(new { Status = "Success" });
        }
        #endregion

        #region Edit
        [CustomAuthorize] //retrieving user details from dB
        public ActionResult Edit(string id_value)
        {

            _Logger.Debug("id_value = " + id_value);
            User User = new User();
            User.UserId = id_value;
            string URL = BaseURL + "RetrieveUser";
            _Logger.Debug("URL = " + URL);
            try
            {
                string UserDataResponse = ServiceConsumer.Post(URL, User);
                _Logger.Debug("UserDataResponse = " + UserDataResponse);
                User UserData = JsonConvert.DeserializeObject<User>(UserDataResponse);
                LogHelper.LogMaker(UserData);
                ViewData["UserData"] = UserData; //show user details in textboxes
                return View(UserData);
            }

            catch (Exception exception)
            {
                _Logger.Error(exception.Message, exception);
                throw exception;
            }

        }
        #endregion

        #region Create

        public ActionResult Create()
        {
            return View(new User());
        }
        #endregion

        #region UpdateUser
        [WebMethod]
        public JsonResult UpdateUser(User objUser)
        {
            _Logger.Info("Method Start");
            string URL = BaseURL + "Update";
            _Logger.Debug("URL = " + URL);
            try
            {
                LogHelper.LogMaker(objUser);
                string UserDataResponse = ServiceConsumer.Post(URL, objUser);
                _Logger.Debug("UserDataResponse = " + UserDataResponse);
            }

            catch (Exception exception)
            {
                _Logger.Error(exception.Message, exception);
                var ErrorDetail = JObject.Parse(exception.Message)["ErrorDetail"].ToString();
                return Json(new { Status = ErrorDetail });
            }

            _Logger.Info("Method End");
            return Json(new { Status = "Success" });

        }
        #endregion

        #region Delete
        public ActionResult Delete(string id_value)
        {

            _Logger.Debug("id_value = " + id_value);
            User User = new User();
            User.UserId = id_value;
            string URL = BaseURL + "Delete";
            _Logger.Debug("URL = " + URL);
            try
            {
                string UserDataResponse = ServiceConsumer.Post(URL, User);
                _Logger.Debug("UserDataResponse = " + UserDataResponse);
            }

            catch (Exception exception)
            {
                _Logger.Error(exception.Message, exception);
                throw exception;
            }

            return RedirectToAction("Index", "User");
        }
        #endregion


    }
}
