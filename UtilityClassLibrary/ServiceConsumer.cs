using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using DataObjects;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Utilities
{
    public static class ServiceConsumer
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static HttpWebResponse Get(string url)
        {
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse HttpResponse = (HttpWebResponse)Request.GetResponse();
                return HttpResponse;

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

        public static HttpWebResponse Post(string url, Object user)
        {
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(url);

                var RequestData = new { user = user };
                Request.Method = "POST";
                Request.ContentType = "application/json";

                using (StreamWriter Writer = new StreamWriter(Request.GetRequestStream()))
                {
                    Writer.Write(JsonConvert.SerializeObject(RequestData, Formatting.Indented));

                }

                HttpWebResponse HttpResponse = (HttpWebResponse)Request.GetResponse();

                return HttpResponse;

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
    }
}
