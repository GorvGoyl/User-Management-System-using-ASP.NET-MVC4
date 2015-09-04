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
        #region Create
        public static void Create(User user)
        {
            Logger.Debug("Method Start");
            try
            {
                LogHelper.LogMaker(user);
                User_MySQL.Create(user);
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
                UserData = User_MySQL.RetrieveUser(user);
                LogHelper.LogMaker(user);
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
                UsersList = User_MySQL.Retrieve();
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
                User_MySQL.Update(user);
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
                User_MySQL.Delete(user);
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


