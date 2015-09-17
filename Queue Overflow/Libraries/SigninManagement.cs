using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Security;
using QueueOverflow.Models;
using Newtonsoft.Json;
using System.Web;

namespace QueueOverflow.Libraries
{
    public class SigninManagement
    {
        private static readonly log4net.ILog _Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region SetAuthCookie
        public static void SetAuthCookie(User user, string userDataResponse)
        {
            HttpCookie CustomAuthCookie = new HttpCookie("MXAuthCookie");
            FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(
               1,
               user.UserName,
               DateTime.Now,
               DateTime.Now.AddMinutes(30),
               false,
               userDataResponse,
               CustomAuthCookie.Path);

            string EncTicket = FormsAuthentication.Encrypt(Ticket);
            _Logger.Debug("EncTicket = " + EncTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(CustomAuthCookie.Name, EncTicket));
      
        }
        #endregion

        #region GetAuthCookieData
        public static User GetAuthCookieData()
        {
            //HttpCookie cookie = HttpContext.Request.Cookies["MXAuthCookie"];
            HttpCookie Cookie = HttpContext.Current.Request.Cookies.Get("MXAuthCookie");
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Cookie.Value);
            User User;
            string UserData = ticket.UserData;
            try
            {
                User = JsonConvert.DeserializeObject<User>(UserData);
            }
            catch (Exception exception)
            {
                _Logger.Error(exception.Message, exception);
                throw exception;
            }
            return User;

        }
        #endregion

    }
}