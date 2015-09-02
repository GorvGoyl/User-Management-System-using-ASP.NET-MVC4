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
    public class BusinessLayer
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<User> RetrieveAllData()
        {
            Logger.Debug("Method Start");
            List<User> UsersList;
            try
            {
                UsersList = DataLayer.RetrieveAllData();
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

                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            Logger.Debug("Method End");
            return UsersList;

        }

        public static User RetrieveUser(string guid)
        {
            Logger.Debug("Method Start");
            Logger.Debug(guid);
            User UserData;
            try
            {
                UserData = DataLayer.RetrieveUser(guid);
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

        public static void AddUser(User user)
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
                DataLayer.AddUserToDB(user);
            }
            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                throw exception;
            }
           
            Logger.Debug("Method End");

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
                DataLayer.UpdateUser(user);
            }

            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            Logger.Debug("Method End");

        }

        public static void DeleteUser(string guid)
        {
            Logger.Debug("Method Start");
            Logger.Debug(guid);
            try
            {
                DataLayer.DeleteUser(guid);
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
            //Logger.Debug(guid);
            User UserData;
            try
            {
                UserData = DataLayer.RetrieveUser(user);
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

    }
}


