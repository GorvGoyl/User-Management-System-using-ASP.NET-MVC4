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
namespace MVC4_Html_Table.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Index()
        {
            Logger.Debug("Method Start");
            try
            {
                WebRequest Request = WebRequest.Create("http://localhost:65000/Service1.svc/RetrieveAll");
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
                                List<User> UserData = JsonConvert.DeserializeObject<List<User>>(ResponseFromServer);
                                ViewData["UserData"] = UserData;
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
            catch (WebException webExcp)
            {
                // If you reach this point, an exception has been caught.
                Logger.Debug("A WebException has been caught.");
                // Write out the WebException message.
                Logger.Debug(webExcp.ToString());
                // Get the WebException status code.
                WebExceptionStatus status = webExcp.Status;
                // If status is WebExceptionStatus.ProtocolError, 
                //   there has been a protocol error and a WebResponse 
                //   should exist. Display the protocol error.
                if (status == WebExceptionStatus.ProtocolError)
                {
                    Logger.Debug("The server returned protocol error ");
                    // Get HttpWebResponse so that you can check the HTTP status code.
                    HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                    Logger.Debug((int)httpResponse.StatusCode + " - "
                       + httpResponse.StatusCode);
                }
                throw webExcp;
            }
            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                throw exception;
 
            }
            Logger.Debug("Method End");
            return View();
        }

        public ActionResult Create() //redirect to edit action with guid = 0
        {
            Logger.Debug("Method Start");

            Logger.Debug("Method End");
            return RedirectToAction("Edit", "Home", new { guid_value = 0 });

        }


        public ActionResult Edit(string guid_value) //guid = 0 when it's invoked from Create() action
        {
            Logger.Debug("Method Start");
            Logger.Debug(guid_value);
            if (!guid_value.Equals("0"))  //it means updating existing user with some guid value
            {
                try
                {
                    HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("http://localhost:65000/Service1.svc/Edit");
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
                catch (WebException webExcp)
                {
                    // If you reach this point, an exception has been caught.
                    Logger.Debug("A WebException has been caught.");
                    // Write out the WebException message.
                    Logger.Debug(webExcp.ToString());
                    // Get the WebException status code.
                    WebExceptionStatus status = webExcp.Status;
                    // If status is WebExceptionStatus.ProtocolError, 
                    //   there has been a protocol error and a WebResponse 
                    //   should exist. Display the protocol error.
                    //if (status == WebExceptionStatus.ProtocolError)
                   // {
                        Logger.Debug("The server returned protocol error ");
                        // Get HttpWebResponse so that you can check the HTTP status code.
                        HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                        Logger.Debug((int)httpResponse.StatusCode + " - "
                           + httpResponse.StatusCode);
                   // }
                    throw webExcp;
                }
                catch (Exception exception)
                {
                    Logger.Debug(exception.Message, exception);
                    throw exception;

                }
            }

            Logger.Debug("Method End");
            return View(new User());  //else pass the empty user details in textboxes
        }

        [HttpPost]  //posting the data to dB
        public ActionResult Edit(User user) //one action for both update and create user
        {
            Logger.Debug("Method Start");
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(user.GUID))    //If it's a new User
                {

                    List<string> UserData = new List<string>();

                    Guid NewGUID = Guid.NewGuid();
                    user.GUID = NewGUID.ToString();

                    UserData.Add(user.GUID);
                    UserData.Add(user.Name ?? string.Empty);
                    UserData.Add(user.Phone ?? string.Empty);
                    UserData.Add(user.City ?? string.Empty);
                    UserData.Add(user.DOB ?? "2000-01-01");
                    UserData.Add(user.EMail ?? string.Empty);
                    try
                    {
                        HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("http://localhost:65000/Service1.svc/AddUser");
                        var RequestData = new { userData = UserData };

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
                                    string Result = Reader.ReadToEnd();

                                }
                            }
                        }
                    }
                    catch (WebException webExcp)
                    {
                        // If you reach this point, an exception has been caught.
                        Logger.Debug("A WebException has been caught.");
                        // Write out the WebException message.
                        Logger.Debug(webExcp.ToString());
                        // Get the WebException status code.
                        WebExceptionStatus status = webExcp.Status;
                        // If status is WebExceptionStatus.ProtocolError, 
                        //   there has been a protocol error and a WebResponse 
                        //   should exist. Display the protocol error.
                        if (status == WebExceptionStatus.ProtocolError)
                        {
                            Logger.Debug("The server returned protocol error ");
                            // Get HttpWebResponse so that you can check the HTTP status code.
                            HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                            Logger.Debug((int)httpResponse.StatusCode + " - "
                               + httpResponse.StatusCode);
                        }
                        throw webExcp;
                    }
                    catch (Exception exception)
                    {
                        Logger.Debug(exception.Message, exception);
                        throw exception;

                    }
                }
                else    //update the existing user
                {
                    List<string> UserData = new List<string>();

                    UserData.Add(user.GUID);
                    UserData.Add(user.Name ?? string.Empty);
                    UserData.Add(user.Phone ?? string.Empty);
                    UserData.Add(user.City ?? string.Empty);
                    UserData.Add(user.DOB ?? "2000-01-01");
                    UserData.Add(user.EMail ?? string.Empty);
                    try
                    {
                        HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("http://localhost:65000/Service1.svc/Update");
                        var RequestData = new { userData = UserData };
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
                                    string Result = Reader.ReadToEnd();

                                }
                            }
                        }
                    }
                    catch (WebException webExcp)
                    {
                        // If you reach this point, an exception has been caught.
                        Logger.Debug("A WebException has been caught.");
                        // Write out the WebException message.
                        Logger.Debug(webExcp.ToString());
                        // Get the WebException status code.
                        WebExceptionStatus status = webExcp.Status;
                        // If status is WebExceptionStatus.ProtocolError, 
                        //   there has been a protocol error and a WebResponse 
                        //   should exist. Display the protocol error.
                        if (status == WebExceptionStatus.ProtocolError)
                        {
                            Logger.Debug("The server returned protocol error ");
                            // Get HttpWebResponse so that you can check the HTTP status code.
                            HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                            Logger.Debug((int)httpResponse.StatusCode + " - "
                               + httpResponse.StatusCode);
                        }
                        throw webExcp;
                    }
                    catch (Exception exception)
                    {
                        Logger.Debug(exception.Message, exception);
                        throw exception;

                    }
                }
                Logger.Debug("Method End");
                return RedirectToAction("Index", "Home");
            }
            return View(user);

        }

        public ActionResult Delete(string guid)
        {
            Logger.Debug("Method Start");
            Logger.Debug(guid);
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("http://localhost:65000/Service1.svc/Delete");
                var RequestData = new { guid = guid };
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

                    }
                }

            }
            catch (WebException webExcp)
            {
                // If you reach this point, an exception has been caught.
                Logger.Debug("A WebException has been caught.");
                // Write out the WebException message.
                Logger.Debug(webExcp.ToString());
                // Get the WebException status code.
                WebExceptionStatus status = webExcp.Status;
                // If status is WebExceptionStatus.ProtocolError, 
                //   there has been a protocol error and a WebResponse 
                //   should exist. Display the protocol error.
                if (status == WebExceptionStatus.ProtocolError)
                {
                    Logger.Debug("The server returned protocol error ");
                    // Get HttpWebResponse so that you can check the HTTP status code.
                    HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                    Logger.Debug((int)httpResponse.StatusCode + " - "
                       + httpResponse.StatusCode);
                }
                throw webExcp;
            }
            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                throw exception;

            }
            Logger.Debug("Method End");
            return RedirectToAction("Index", "Home");
        }


    }
}
