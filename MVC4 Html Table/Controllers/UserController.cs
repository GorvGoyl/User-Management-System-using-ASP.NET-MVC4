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
namespace MVC4_Html_Table.Controllers
{
    public class UserController : BaseController
    {
        private readonly ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string BaseURL = ConfigurationManager.AppSettings["UserServiceURL"].ToString();

        #region Index
        [CustomAuthorize]
        public ActionResult Index()
        {

            string URL = BaseURL + "Retrieve";
            try
            {
                string ResponseFromServer = ServiceConsumer.Get(URL);
                Logger.Debug(ResponseFromServer);
                try
                {
                    List<User> UsersList = JsonConvert.DeserializeObject<List<User>>(ResponseFromServer);
                    string JsonUser = JsonConvert.SerializeObject(UsersList);
                    Logger.Debug(JsonUser);
                    ViewData["UserData"] = UsersList;
                }
                catch (Exception exception)
                {
                    Logger.Error(exception.Message, exception);
                    throw exception;
                }


            }

            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                throw exception;
            }

            return View();
        }
        #endregion

        #region Create
        [CustomAuthorize]
        public ActionResult Create()
        {
            return View(new User());
        }
        #endregion

        #region Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                Guid NewGUID = Guid.NewGuid();
                Logger.Debug(NewGUID);
                user.UserId = NewGUID.ToString();
                string URL = BaseURL + "Create";
                try
                {
                    Logger.Debug(user);
                    string ResponseFromServer = ServiceConsumer.Post(URL,user);
                    Logger.Debug(ResponseFromServer);
                    string JsonUser = JsonConvert.SerializeObject(user);
                    Logger.Debug(JsonUser);
                }

                catch (Exception exception)
                {
                    Logger.Error(exception.Message, exception);
                    throw exception;
                }


                return RedirectToAction("Index", "User");
            }
            return View(user);

        }
        #endregion

        #region Edit
        [CustomAuthorize] //retrieving user details from dB
        public ActionResult Edit(string id_value)
        {

            Logger.Debug(id_value);
            User User = new User();
            User.UserId = id_value;
            string URL = BaseURL + "RetrieveUser";
            try
            {
                string UserDataResponse = ServiceConsumer.Post(URL, User);
                Logger.Debug(UserDataResponse);
                User UserData = JsonConvert.DeserializeObject<User>(UserDataResponse);
                Logger.Debug(UserData);
                ViewData["UserData"] = UserData; //show user details in textboxes
                return View(UserData);
            }

            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                throw exception;
            }

        }
        #endregion

        #region Edit
        [HttpPost]  //posting the data to dB
        public ActionResult Edit(User user)
        {

            string URL = BaseURL + "Update";
            if (ModelState.IsValid)
            {
                try
                {
                    Logger.Debug(user);
                    string UserDataResponse = ServiceConsumer.Post(URL, User);
                    Logger.Debug(UserDataResponse);
                }

                catch (Exception exception)
                {
                    Logger.Error(exception.Message, exception);
                    throw exception;
                }

                return RedirectToAction("Index", "User");
            }
            return View(user);

        }
        #endregion

        #region Delete
        [CustomAuthorize]
        public ActionResult Delete(string id_value)
        {

            Logger.Debug(id_value);
            User User = new User();
            User.UserId = id_value;
            string URL = BaseURL + "Delete";
            try
            {
                string UserDataResponse = ServiceConsumer.Post(URL, User);
                Logger.Debug(UserDataResponse);
            }

            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                throw exception;
            }

            return RedirectToAction("Index", "User");
        }
        #endregion

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
