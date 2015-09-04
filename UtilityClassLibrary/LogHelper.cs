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
        private static readonly ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region LogMaker
        public static void LogMaker(User user)
        {
            Logger.Debug("Method Start");
            try
            {
                string JsonUser = JsonConvert.SerializeObject(user);
                Logger.Debug(JsonUser);
            }
            catch (Exception exception)
            {

                Logger.Error(exception.Message, exception);
                throw exception;
            }
            Logger.Debug("Method End");
        }
        #endregion

        #region LogMaker
        public static void LogMaker(List<User> usersList)
        {
            Logger.Debug("Method Start");
            try
            {
                string JsonUser = JsonConvert.SerializeObject(usersList);
                Logger.Debug(usersList);
            }
            catch (Exception exception)
            {

                Logger.Error(exception.Message, exception);
                throw exception;
            }
            Logger.Debug("Method End");
        }
        #endregion
    }
}
