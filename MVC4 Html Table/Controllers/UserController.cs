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
    public class UserController : Controller
    {
        private readonly ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string BaseURL = ConfigurationManager.AppSettings["UserTableServiceURL"].ToString();

        [CustomAuthorize]
        public ActionResult Index()
        {
            Logger.Debug("Method Start");
            try
            {


                WebRequest Request = WebRequest.Create(BaseURL + "RetrieveAll");
                using (WebResponse Response = Request.GetResponse())
                {
                    Logger.Debug(((HttpWebResponse)Response).StatusDescription);
                    using (Stream dataStream = Response.GetResponseStream())
                    {
                        using (StreamReader Reader = new StreamReader(dataStream))
                        {
                            string ResponseFromServer = Reader.ReadToEnd();
                            Logger.Debug(ResponseFromServer);
                            try
                            {
                                List<User> UsersList = JsonConvert.DeserializeObject<List<User>>(ResponseFromServer);
                                try
                                {
                                    string JsonUser = JsonConvert.SerializeObject(UsersList);
                                    Logger.Debug(JsonUser);
                                }
                                catch (Exception exception)
                                {

                                    Logger.Debug(exception.Message, exception);
                                    throw exception;
                                }
                                ViewData["UserData"] = UsersList;
                            }
                            catch (Exception exception)
                            {
                                Logger.Debug(exception.Message, exception);
                                throw exception;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                var protocolException = exception as WebException;
                if (protocolException != null)
                {
                    var responseStream = protocolException.Response.GetResponseStream();
                    var error = new StreamReader(protocolException.Response.GetResponseStream()).ReadToEnd();
                    var ErrorInfoMessage = JToken.Parse(error)["ErrorInfo"];
                    throw new Exception(ErrorInfoMessage.ToString());
                }
                else
                {
                    throw new Exception("There is an unexpected error", exception);
                }

            }
            Logger.Debug("Method End");
            return View();
        }
        [CustomAuthorize]
        public ActionResult Create() 
        {
            Logger.Debug("Method Start");

            Logger.Debug("Method End");
            return View(new User());

        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            Logger.Debug("Method Start");
            try
            {
                string JsonUser = JsonConvert.SerializeObject(user);
                Logger.Debug(JsonUser);
            }
            catch (Exception exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }

            if (ModelState.IsValid)
            {
                Guid NewGUID = Guid.NewGuid();
                Logger.Debug(NewGUID);
                user.GUID = NewGUID.ToString();
                try
                {
                    HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(BaseURL + "AddUser");
                    var RequestData = new { user = user };
                    Request.Method = "POST";
                    Request.ContentType = "application/json";
                    using (StreamWriter Writer = new StreamWriter(Request.GetRequestStream()))
                    {
                        Writer.Write(JsonConvert.SerializeObject(RequestData, Formatting.Indented));
                    }
                    using (HttpWebResponse Response = (HttpWebResponse)Request.GetResponse())
                    {
                    }
                }

                catch (Exception exception)
                {
                    Logger.Debug(exception.Message, exception);
                    var protocolException = exception as WebException;
                    if (protocolException.Response != null)
                    {
                        var responseStream = protocolException.Response.GetResponseStream();
                        var error = new StreamReader(protocolException.Response.GetResponseStream()).ReadToEnd();
                        var ErrorInfoMessage = JToken.Parse(error)["ErrorInfo"];
                        throw new Exception(ErrorInfoMessage.ToString());
                    }
                    else
                        throw new Exception("There is an unexpected error", exception);
                }

                Logger.Debug("Method End");
                return RedirectToAction("Index", "User");
            }
            return View(user);

        }

        [CustomAuthorize]
        public ActionResult Edit(string guid_value) 
        {
            Logger.Debug("Method Start");
            Logger.Debug(guid_value);
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(BaseURL + "Edit");
                var RequestData = new { guid = guid_value };
                Request.Method = "POST";
                Request.ContentType = "application/json";

                using (StreamWriter Writer = new StreamWriter(Request.GetRequestStream()))
                {
                    Writer.Write(JsonConvert.SerializeObject(RequestData, Formatting.Indented));

                }
                using (HttpWebResponse Response = (HttpWebResponse)Request.GetResponse())
                {
                    using (Stream DataStream = Response.GetResponseStream())
                    {

                        using (StreamReader Reader = new StreamReader(DataStream))
                        {
                            string UserDataResponse = Reader.ReadToEnd();
                            Logger.Debug(UserDataResponse);
                            User UserData = JsonConvert.DeserializeObject<User>(UserDataResponse);
                            ViewData["UserData"] = UserData; //show user details in textboxes

                            Logger.Debug("Method End");
                            return View(UserData);
                        }
                    }
                }

            }

            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                var protocolException = exception as WebException;
                if (protocolException != null)
                {
                    var responseStream = protocolException.Response.GetResponseStream();
                    var error = new StreamReader(protocolException.Response.GetResponseStream()).ReadToEnd();
                    var ErrorInfoMessage = JToken.Parse(error)["ErrorInfo"];
                    throw new Exception(ErrorInfoMessage.ToString());
                }
                else
                {
                    throw new Exception("There is an unexpected error", exception);
                }
            }

        }

        [HttpPost]  //posting the data to dB
        public ActionResult Edit(User user)
        {
            Logger.Debug("Method Start");
            try
            {
                string JsonUser = JsonConvert.SerializeObject(user);
                Logger.Debug(JsonUser);
            }
            catch (Exception exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(BaseURL + "Update");
                    var RequestData = new { user = user };
                    Request.Method = "POST";
                    Request.ContentType = "application/json";
                    using (StreamWriter Writer = new StreamWriter(Request.GetRequestStream()))
                    {
                        Writer.Write(JsonConvert.SerializeObject(RequestData, Formatting.Indented));
                    }
                    using (HttpWebResponse Response = (HttpWebResponse)Request.GetResponse())
                    {
                    }
                }

                catch (Exception exception)
                {
                    Logger.Debug(exception.Message, exception);
                    var protocolException = exception as WebException;
                    if (protocolException != null)
                    {
                        var responseStream = protocolException.Response.GetResponseStream();
                        var error = new StreamReader(protocolException.Response.GetResponseStream()).ReadToEnd();
                        var ErrorInfoMessage = JToken.Parse(error)["ErrorInfo"];
                        throw new Exception(ErrorInfoMessage.ToString());
                    }
                    else
                        throw new Exception("There is an unexpected error", exception);
                }
                Logger.Debug("Method End");
                return RedirectToAction("Index", "User");
            }
            return View(user);

        }

        [CustomAuthorize]
        public ActionResult Delete(string guid_value)
        {
            Logger.Debug("Method Start");
            Logger.Debug(guid_value);
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(BaseURL + "Delete");
                var RequestData = new { guid = guid_value };
                Request.Method = "POST";
                Request.ContentType = "application/json";

                using (StreamWriter Writer = new StreamWriter(Request.GetRequestStream()))
                {
                    Writer.Write(JsonConvert.SerializeObject(RequestData, Formatting.Indented));
                }

                using (HttpWebResponse Response = (HttpWebResponse)Request.GetResponse())
                {

                }

            }

            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                var protocolException = exception as WebException;
                if (protocolException != null)
                {
                    var responseStream = protocolException.Response.GetResponseStream();
                    var error = new StreamReader(protocolException.Response.GetResponseStream()).ReadToEnd();
                    var ErrorInfoMessage = JToken.Parse(error)["ErrorInfo"];
                    throw new Exception(ErrorInfoMessage.ToString());
                }
                else
                    throw new Exception("There is an unexpected error", exception);

            }
            Logger.Debug("Method End");
            return RedirectToAction("Index", "User");
        }

        //[CustomAuthorize] // This is for Authorize user
        //public ActionResult MyProfile()
        //{
        //    Logger.Debug("Method Start");
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
        //    Logger.Debug("Method End");
        //    return View();
        //}


    }
}
