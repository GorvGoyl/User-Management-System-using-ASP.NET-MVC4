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
        private static readonly ILog _Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region LogMaker
        public static void LogMaker(Object obj)
        {
            _Logger.Info("Method Start");
            try
            {
                _Logger.Debug(JsonConvert.SerializeObject(obj));
            }
            catch (Exception exception)
            {

                _Logger.Error(exception.Message, exception);
                throw exception;
            }
            _Logger.Info("Method End");
        }
        #endregion

        //public static void LogMaker(User user)
        //{
        //    Logger.Info("Method Start");
        //    try
        //    {
        //        string JsonUser = JsonConvert.SerializeObject(user);
        //        Logger.Debug(JsonUser);
        //    }
        //    catch (Exception exception)
        //    {

        //        Logger.Error(exception.Message, exception);
        //        throw exception;
        //    }
        //    Logger.Info("Method End");
        //}
      
        //public static void LogMaker(List<User> usersList)
        //{
        //    Logger.Info("Method Start");
        //    try
        //    {
        //        string JsonUser = JsonConvert.SerializeObject(usersList);
        //        Logger.Debug(usersList);
        //    }
        //    catch (Exception exception)
        //    {

        //        Logger.Error(exception.Message, exception);
        //        throw exception;
        //    }
        //    Logger.Info("Method End");
        //}
    }
}
