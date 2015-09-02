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
namespace MVC4_Html_Table.Controllers
{
    public class HomeController : Controller
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string BaseURL = ConfigurationManager.AppSettings["UserTableServiceURL"].ToString();
        [AllowAnonymous] //This is for Un-Authorize User
        public ActionResult Index()
        {
            Logger.Debug("Method Start");

            Logger.Debug("Method End");
            return View();
        }


        public ActionResult Register()
        {
            Logger.Debug("Method Start");

            Logger.Debug("Method End");
            return RedirectToAction("Create", "User", "Create");
        }


        public ActionResult Login()
        {
            Logger.Debug("Method Start");

            Logger.Debug("Method End");
            return View();
        }


        [HttpPost]
        public ActionResult Login(User user)
        {
            Logger.Debug("Method Start");


            if (ModelState.IsValid)
            {
                try
                {
                    HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(BaseURL + "ValidateUser");
                    var RequestData = new { user = user };
                    Request.Method = "POST";
                    Request.ContentType = "application/json";

                    using (StreamWriter Writer = new StreamWriter(Request.GetRequestStream()))
                    {
                        Writer.Write(JsonConvert.SerializeObject(RequestData, Formatting.Indented));

                    }
                    using (HttpWebResponse HttpResponse = (HttpWebResponse)Request.GetResponse())
                    {
                        using (Stream DataStream = HttpResponse.GetResponseStream())
                        {

                            using (StreamReader Reader = new StreamReader(DataStream))
                            {
                                string UserDataResponse = Reader.ReadToEnd();
                                Logger.Debug(UserDataResponse);
                                User UserData = JsonConvert.DeserializeObject<User>(UserDataResponse);
                                if (String.IsNullOrEmpty(UserData.UserName))
                                {
                                    ViewBag.Message = "username or password is incorrect";
                                    ModelState.Remove("Password");
                                    Logger.Debug("Method End");
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
            else
            {

                ModelState.Remove("Password");
                return View();
            }

        }


        [CustomAuthorize]
        public ActionResult Logout()
        {
            Logger.Debug("Method Start");
            HttpContext.Response.Cookies.Remove("MXGourav");
            HttpContext.Response.Cookies["MXGourav"].Value = null;
            //Clearing the cookies of the response doesn't instruct the
            //browser to clear the cookie, it merely does not send the cookie back to the browser.
            //To instruct the browser to clear the cookie you need to tell it the cookie has expired
            HttpContext.Response.Cookies["MXGourav"].Expires = DateTime.Now.AddMonths(-1);

            return RedirectToAction("Login", "Home");
        }

    }
}
