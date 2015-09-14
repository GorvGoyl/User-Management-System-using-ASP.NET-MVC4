using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC4_Html_Table.Filters;
using System.Web.Security;
using Newtonsoft.Json;
using MVC4_Html_Table.Models;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Configuration;
using Utilities;
namespace MVC4_Html_Table.Controllers
{
    public class HomeController : BaseController
    {
        private static readonly log4net.ILog _Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string BaseURL = ConfigurationManager.AppSettings["UserServiceURL"].ToString();

        #region Password
        public ActionResult Password()
        {
            ViewBag.Pass = string.Empty;
            return View();
        }
        #endregion

        //#region Password ajax
        //public JsonResult GetPassword(User objUser) //passing the username and email
        //{
        //    _Logger.Info("Method Start");
        //    string URL = BaseURL + "RetrieveUser";
        //    _Logger.Debug("URL = " + URL);
        //    string ResponseFromServer = "";
        //    try
        //    {
        //        LogHelper.LogMaker(objUser);
        //        ResponseFromServer = ServiceConsumer.Post(URL, objUser);
        //        _Logger.Debug("ResponseFromServer = " + ResponseFromServer);
        //    }

        //    catch (Exception exception)
        //    {
        //        _Logger.Error(exception.Message, exception);
        //        throw exception;
        //    }

        //    _Logger.Info("Method End");
        //    return Json(ResponseFromServer);
        //}
        //#endregion

        #region Password Post
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Password(User user) //passing the username and email
        {
            string URL = BaseURL + "RetrieveUser";
            _Logger.Debug("URL = " + URL);
            try
            {
                LogHelper.LogMaker(user);
                string UserDataResponse = ServiceConsumer.Post(URL, user);
                _Logger.Debug("UserDataResponse = " + UserDataResponse);
                
                User UserData = JsonConvert.DeserializeObject<User>(UserDataResponse);
                LogHelper.LogMaker(UserData);
                
                if (UserData.Password != null)
                {
                    ViewBag.Pass = "Password : " + UserData.Password;
                    return View();
                }
                else
                {
                    ViewBag.Pass = "Username or Email is incorrect";
                    return View();
                }
            }

            catch (Exception exception)
            {
                _Logger.Error(exception.Message, exception);
                throw exception;
            }
        }
        #endregion

        #region Error
        public ActionResult Error()
        {
            return View();
        }
        #endregion

        #region Demo
        public ActionResult Demo()
        {

            return View();
        }
        #endregion

        #region Register

        public ActionResult Register()
        {
            ViewBag.Pass = string.Empty;
            return View(new User());
        }
        #endregion

        #region Register Post
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Register(User user)
        {
            User CheckUser = new User();
            CheckUser.UserName = user.UserName;
            string UserResponseFromServer = ServiceConsumer.Post(BaseURL + "Retrieveuser", CheckUser);
            User RetrieveUser = JsonConvert.DeserializeObject<User>(UserResponseFromServer);
            if(!String.IsNullOrEmpty(RetrieveUser.UserName))
            {
                ViewBag.Pass = "UserName already Exist";
                ModelState.Remove("UserName");
                return View();
            }
            Guid NewGUID = Guid.NewGuid();
            _Logger.Debug(NewGUID);
            user.UserId = NewGUID.ToString();
            string URL = BaseURL + "Create";
            _Logger.Debug("URL = " + URL);
            try
            {
                LogHelper.LogMaker(user);
                string ResponseFromServer = ServiceConsumer.Post(URL, user);
                _Logger.Debug("ResponseFromServer = " + ResponseFromServer);
                string JsonUser = JsonConvert.SerializeObject(user);
                _Logger.Debug(JsonUser);
            }

            catch (Exception exception)
            {
                _Logger.Error(exception.Message, exception);
                throw exception;
            }
            return RedirectToAction("Index", "User");

        }
        #endregion

        #region Login
        public ActionResult Login()
        {
            ViewBag.Pass = string.Empty;
            if (Request.Cookies["MXGourav"] != null)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }
        #endregion

        #region Login Post
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Login(User user) //passing the username and password
        {
            string URL = BaseURL + "RetrieveUser";
            _Logger.Debug("URL = " + URL);
            try
            {
                LogHelper.LogMaker(user);
                string UserDataResponse = ServiceConsumer.Post(URL, user);
                _Logger.Debug("UserDataResponse = " + UserDataResponse);
                User UserData = JsonConvert.DeserializeObject<User>(UserDataResponse);
                LogHelper.LogMaker(UserData);
                if (String.IsNullOrEmpty(UserData.UserName))
                {
                    ViewBag.Pass = "UserName or Password is incorrect";
                    ModelState.Remove("Password");
                    return View();
                }

                HttpCookie CustomAuthCookie = new HttpCookie("MXGourav");
                FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(
                   1,
                   user.UserName,
                   DateTime.Now,
                   DateTime.Now.AddMinutes(30),
                   false,
                   UserDataResponse,
                   CustomAuthCookie.Path);

                string EncTicket = FormsAuthentication.Encrypt(Ticket);
                _Logger.Debug("EncTicket = " + EncTicket);
                Response.Cookies.Add(new HttpCookie(CustomAuthCookie.Name, EncTicket));
                return RedirectToAction("Index", "User");

            }

            catch (Exception exception)
            {
                _Logger.Error(exception.Message, exception);
                throw exception;
            }

        }


        #endregion

        #region Logout
        public ActionResult Logout()
        {

            HttpContext.Response.Cookies.Remove("MXGourav");
            HttpContext.Response.Cookies["MXGourav"].Value = null;
            //Clearing the cookies of the response doesn't instruct the
            //browser to clear the cookie, it merely does not send the cookie back to the browser.
            //To instruct the browser to clear the cookie you need to tell it the cookie has expired
            HttpContext.Response.Cookies["MXGourav"].Expires = DateTime.Now.AddMonths(-1);
            return RedirectToAction("Login", "Home");
        }
        #endregion

    }
}
