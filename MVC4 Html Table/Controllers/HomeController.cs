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
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string BaseURL = ConfigurationManager.AppSettings["UserTableServiceURL"].ToString();

        #region Index
        [AllowAnonymous] //This is for Un-Authorize User
        public ActionResult Index()
        {
            return View();
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

            return RedirectToAction("Create", "User", "Create");
        }
        #endregion

        #region Login
        public ActionResult Login()
        {
            //throw new Exception();
            return View();
        }
        #endregion

        #region Login
        [HttpPost]
        public ActionResult Login(User user) //passing the username and password
        {
            string URL = BaseURL + "RetrieveUser";
            if (ModelState.IsValid)
            {
                try
                {
                    Logger.Debug(user);
                    string UserDataResponse = ServiceConsumer.Post(URL, User);
                    Logger.Debug(UserDataResponse);
                    User UserData = JsonConvert.DeserializeObject<User>(UserDataResponse);
                    if (String.IsNullOrEmpty(UserData.UserName))
                    {
                        ViewBag.Message = "username or password is incorrect";
                        ModelState.Remove("Password");
                        return View();
                    }

                    HttpCookie CustomAuthCookie = new HttpCookie("MXGourav");
                    FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(
                       1,
                       user.UserName,
                       DateTime.Now,
                       DateTime.Now.AddMinutes(30),
                       true,
                       UserDataResponse,
                       CustomAuthCookie.Path);

                    string EncTicket = FormsAuthentication.Encrypt(Ticket);
                    Response.Cookies.Add(new HttpCookie(CustomAuthCookie.Name, EncTicket));
                    return RedirectToAction("Index", "User");

                }

                catch (Exception exception)
                {
                    Logger.Error(exception.Message, exception);
                    throw exception;
                }

            }
            else
            {
                ModelState.Remove("Password");
                return View();
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
