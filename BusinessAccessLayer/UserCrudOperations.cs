using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;
using DataObjects;
using System.Net;
using Utilities;
namespace BusinessAccessLayer
{
    public class UserCrudOperations
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Create(User user)
        {
            Logger.Debug("Method Start");
            try
            {
                CustomJson.JsonAndLog(user);
            }
            catch (Exception exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            try
            {
                User_MySQL.Create(user);
            }
            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                throw exception;
            }

            Logger.Debug("Method End");

        }        

        public static User RetrieveUser(User user)
        {
            Logger.Debug("Method Start");
            User UserData;
            try
            {
                UserData = User_MySQL.RetrieveUser(user);
            }
            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            try
            {
                CustomJson.JsonAndLog(UserData);
            }
            catch (Exception exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            Logger.Debug("Method End");
            return UserData;

        }

        public static List<User> Retrieve()
        {
            Logger.Debug("Method Start");
            List<User> UsersList;
            try
            {
                UsersList = User_MySQL.Retrieve();
            }
            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            try
            {
                CustomJson.JsonAndLog(UsersList);
            }
            catch (Exception exception)
            {

                Logger.Error(exception.Message, exception);
                throw exception;
            }
            Logger.Debug("Method End");
            return UsersList;

        }
        
        public static void Update(User user)
        {
            Logger.Debug("Method Start");
            try
            {
                CustomJson.JsonAndLog(user);
            }
            catch (Exception exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            try
            {
                User_MySQL.Update(user);
            }

            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            Logger.Debug("Method End");

        }

        public static void Delete(User user)
        {
            Logger.Debug("Method Start");
            try
            {
                User_MySQL.Delete(user);
            }
            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            Logger.Debug("Method End");
        }

       

    }
}


