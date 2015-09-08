using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using Newtonsoft.Json;
using log4net;
namespace Utilities
{
    public class LogHelper
    {
        private static readonly ILog Logger;
        static LogHelper()
        {
            Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }


        //public static void LogMaker(User user)
        //{
        //    Logger.Debug("Method Start");
        //    try
        //    {
        //        string JsonUser = JsonConvert.SerializeObject(user);
        //        Logger.Debug(JsonUser);
        //    }
        //    catch (Exception exception)
        //    {

        //        Logger.Debug(exception.Message, exception);
        //        throw exception;
        //    }
        //    Logger.Debug("Method End");
        //}
        public static void LogMaker(Object obj)
        {
            Logger.Debug("Method Start");
            try
            {
                Logger.Debug(JsonConvert.SerializeObject(obj));
            }
            catch (Exception exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            Logger.Debug("Method End");
        }
        //public static void LogMaker(List<User> usersList)
        //{
        //    Logger.Debug("Method Start");
        //    try
        //    {
        //        string JsonUser = JsonConvert.SerializeObject(usersList);
        //        Logger.Debug(usersList);
        //    }
        //    catch (Exception exception)
        //    {

        //        Logger.Debug(exception.Message, exception);
        //        throw exception;
        //    }
        //    Logger.Debug("Method End");
        //}
    }
}
