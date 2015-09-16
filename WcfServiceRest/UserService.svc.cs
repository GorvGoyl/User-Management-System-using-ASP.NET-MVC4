using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BusinessAccessLayer;
using DataObjects;
using Newtonsoft.Json;
using System.Net;
using Utilities;
namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class UserService : IUserService
    {
        private static readonly log4net.ILog _Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Create
        public void Create(User user)
        {
            _Logger.Info("Method Start");
            try
            {
                LogHelper.LogMaker(user);
                Users.Create(user);
            }
            catch (Exception exception)
            {
                _Logger.Error(exception.Message, exception);
                CustomException Error = new CustomException("Unexpected Error caused by " + exception.Source, exception.Message);
                throw new WebFaultException<CustomException>(Error, HttpStatusCode.InternalServerError);
            }
            _Logger.Info("Method End");
        }
        #endregion

        #region RetrieveUser
        public User RetrieveUser(User user)
        {
            _Logger.Info("Method Start");
            _Logger.Debug("Entering rest service retrieve user");
            User UserData;
            try
            {
                LogHelper.LogMaker(user);
                UserData = Users.RetrieveUser(user);
                LogHelper.LogMaker(UserData);
            }
            catch (Exception exception)
            {
                _Logger.Error(exception.Message, exception);
                CustomException Error = new CustomException("Unexpected Error caused by " + exception.Source, exception.Message);
                throw new WebFaultException<CustomException>(Error, HttpStatusCode.InternalServerError);
            }

            _Logger.Info("Method End");
            return UserData;
        }
        #endregion

        #region Retrieve
        public List<User> Retrieve()
        {
            _Logger.Info("Method Start");
            List<User> UsersList;

            try
            {
                UsersList = Users.Retrieve();
                LogHelper.LogMaker(UsersList);

            }
            catch (Exception exception)
            {
                _Logger.Error(exception.Message, exception);
                CustomException Error = new CustomException("Unexpected error caused by " + exception.Source, exception.Message);
                throw new WebFaultException<CustomException>(Error, HttpStatusCode.InternalServerError);
            }

            _Logger.Info("Method End");
            return UsersList;
        }
        #endregion

        #region Update
        public void Update(User user)
        {
            _Logger.Info("Method Start");

            try
            {
                LogHelper.LogMaker(user);
                Users.Update(user);
            }
            catch (Exception exception)
            {
                _Logger.Error(exception.Message, exception);
                CustomException Error = new CustomException("Unexpected Error caused by " + exception.Source, exception.Message);
                throw new WebFaultException<CustomException>(Error, HttpStatusCode.InternalServerError);
            }
            _Logger.Info("Method End");

        }
        #endregion

        #region Delete
        public void Delete(User user)
        {
            _Logger.Info("Method Start");

            try
            {
                LogHelper.LogMaker(user);
                Users.Delete(user);
            }
            catch (Exception exception)
            {
                _Logger.Error(exception.Message, exception);
                CustomException Error = new CustomException("Unexpected Error caused by " + exception.Source, exception.Message);
                throw new WebFaultException<CustomException>(Error, HttpStatusCode.InternalServerError);
            }
            _Logger.Info("Method End");
        }
        #endregion
    }
}
