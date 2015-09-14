using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC4_Html_Table.Models;
using WcfServiceRest;
using Newtonsoft.Json;
using log4net;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using Utilities;
using System.Configuration;
using MVC4_Html_Table.Filters;
using System.Web.Services;
using System.Web.Security;
namespace MVC4_Html_Table.Controllers
{
    public class UserController : BaseController
    {
        private readonly ILog _Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string BaseURL = ConfigurationManager.AppSettings["UserServiceURL"].ToString();

        #region CreateUser 
        [WebMethod]
        public JsonResult CreateUser(User objUser)
        {
            _Logger.Info("Method Start");
            string URL = BaseURL + "Create";
            _Logger.Debug("URL = " + URL);

            objUser.UserId =  Guid.NewGuid().ToString();
            try
            {
                LogHelper.LogMaker(objUser);
                string ResponseFromServer = ServiceConsumer.Post(URL, objUser);
                _Logger.Debug("ResponseFromServer = " + ResponseFromServer);

            }

            catch (Exception exception)
            {
                _Logger.Error(exception.Message, exception);
                throw exception;
            }

            _Logger.Info("Method End");
            return Json(new { Status = "Success" });
        }
        #endregion

        #region SaveUser ajax
        [WebMethod]
        public JsonResult SaveUser(User objUser)
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
                throw exception;
            }
            _Logger.Info("Method End");
            return Json(new { Status = "Success" });

        }
        #endregion

        #region Dashboard
        [CustomAuthorize]
        [ValidateInput(false)]
        public ActionResult Dashboard()
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get("MXGourav");
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
        [CustomAuthorize]
        [ValidateInput(false)]
        public ActionResult Index()
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get("MXGourav");
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            string UserData = ticket.UserData;
            User User = JsonConvert.DeserializeObject<User>(UserData);
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

        #region Create

        public ActionResult Create()
        {
            return View(new User());
        }
        #endregion

        #region Create Post
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(User user)
        {

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

            }

            catch (Exception exception)
            {
                _Logger.Error(exception.Message, exception);
                throw exception;
            }

            return RedirectToAction("Index", "User");

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

        #region Edit Post
        [HttpPost]  //posting the data to dB
        [ValidateInput(false)]
        public ActionResult Edit(User user)
        {

            string URL = BaseURL + "Update";
            _Logger.Debug("URL = " + URL);
            try
            {
                string JsonUser = JsonConvert.SerializeObject(user, Formatting.Indented);
                _Logger.Debug("JsonUser = " + JsonUser);
                
                string UserDataResponse = ServiceConsumer.Post(URL, JsonUser);
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

        #region Delete
        [CustomAuthorize]
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

        //#region GetData
        //public JsonResult GetData() //Show the details of the data after insert in HTML Table
        //{
        //    string URL =BaseURL + "Retrieve";
        //    List<User> UsersList = null;
        //    try
        //    {
        //        string ResponseFromServer = ServiceConsumer.Get(URL);
        //        Logger.Debug("ResponseFromServer = " + ResponseFromServer);

        //            UsersList = JsonConvert.DeserializeObject<List<User>>(ResponseFromServer);
        //            string JsonUser = JsonConvert.SerializeObject(UsersList);
        //            Logger.Debug(JsonUser);
        //    }

        //    catch (Exception exception)
        //    {
        //        Logger.Error(exception.Message, exception);
        //        throw exception;
        //    }
        //    return Json(new {Data = UsersList });
        //}
        //#endregion

        //[CustomAuthorize] // This is for Authorize user
        //public ActionResult MyProfile()
        //{
        //    
        //    if (HttpContext.Request.Cookies["MXGourav"] != null)
        //    {
        //        HttpCookie cookie = HttpContext.Request.Cookies.Get("MXGourav");
        //        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
        //        string Json = ticket.UserData;
        //        List<string> UserData = JsonConvert.DeserializeObject<List<string>>(Json);
        //        ViewBag.UserName = UserData[0];
        //        // ViewBag.Name = UserData[1];
        //        ViewBag.Phone = UserData[2];
        //        ViewBag.City = UserData[3];
        //    }
        //    
        //    return View();
        //}


    }
}
