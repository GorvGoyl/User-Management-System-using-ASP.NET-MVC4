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
    public class Users
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        #region Create
        public static void Create(User user)
        {
            Logger.Debug("Method Start");
            try
            {
                LogHelper.LogMaker(user);
                MySQL_User.Create(user);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                throw exception;
            }

            Logger.Debug("Method End");

        }
        #endregion

        #region RetrieveUser
        public static User RetrieveUser(User user)
        {
            Logger.Debug("Method Start");
            User UserData;
            try
            {
                LogHelper.LogMaker(user);
                UserData = MySQL_User.RetrieveUser(user);
                LogHelper.LogMaker(UserData);


            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                throw exception;
            }

            Logger.Debug("Method End");
            return UserData;

        }
        #endregion

        #region Retrieve
        public static List<User> Retrieve()
        {
            Logger.Debug("Method Start");
            List<User> UsersList;
            try
            {
                UsersList = MySQL_User.Retrieve();
                LogHelper.LogMaker(UsersList);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                throw exception;
            }

            Logger.Debug("Method End");
            return UsersList;

        }
        #endregion

        #region Update
        public static void Update(User user)
        {
            Logger.Debug("Method Start");
            try
            {
                LogHelper.LogMaker(user);
                MySQL_User.Update(user);
            }

            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                throw exception;
            }
            Logger.Debug("Method End");

        }
        #endregion

        #region Delete
        public static void Delete(User user)
        {
            Logger.Debug("Method Start");
            try
            {
                LogHelper.LogMaker(user);
                MySQL_User.Delete(user);
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


