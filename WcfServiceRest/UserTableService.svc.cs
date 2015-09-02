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
namespace WcfServiceRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class UserTableService : IUserTableService
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public List<User> RetrieveAll()
        {
            Logger.Debug("Method Start");
            List<User> UsersList;

            try
            {
                UsersList = BusinessLayer.RetrieveAllData();
            }
            catch (Exception)
            {
                MyCustomException Custom = new MyCustomException("DataBase Error", "Can't retrieve the data from DataBase");
                throw new WebFaultException<MyCustomException>(Custom, HttpStatusCode.BadRequest);
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


        public void AddUser(User user)
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
                BusinessLayer.AddUser(user);
            }
            catch (Exception)
            {
                MyCustomException Custom = new MyCustomException("DataBase Error", "Can't add the data to DataBase");
                throw new WebFaultException<MyCustomException>(Custom, HttpStatusCode.BadRequest);
            }
            Logger.Debug("Method End");
        }

        public void Update(User user)
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
                BusinessLayer.Update(user);
            }
            catch (Exception)
            {
                MyCustomException Custom = new MyCustomException("DataBase Error", "Can't update the data to DataBase");
                throw new WebFaultException<MyCustomException>(Custom, HttpStatusCode.BadRequest);
            }
            Logger.Debug("Method End");

        }

        public User Edit(string guid)
        {
            Logger.Debug("Method Start");
            Logger.Debug(guid);
            User UserData;
            try
            {
                UserData = BusinessLayer.RetrieveUser(guid);
            }
            catch (Exception)
            {
                MyCustomException Custom = new MyCustomException("DataBase Error", "Can't edit the data");
                throw new WebFaultException<MyCustomException>(Custom, HttpStatusCode.BadRequest);
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

        public User ValidateUser(User user)
        {
            Logger.Debug("Method Start");
           
            User UserData;
            try
            {
                UserData = BusinessLayer.RetrieveUser(user);
            }
            catch (Exception)
            {
                MyCustomException Custom = new MyCustomException("DataBase Error", "Can't edit the data");
                throw new WebFaultException<MyCustomException>(Custom, HttpStatusCode.BadRequest);
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
        public void Delete(string guid)
        {
            Logger.Debug("Method Start");
            Logger.Debug(guid);
            try
            {
                BusinessLayer.DeleteUser(guid);
            }
            catch (Exception)
            {
                MyCustomException Custom = new MyCustomException("DataBase Error", "Can't delete the data from DataBase");
                throw new WebFaultException<MyCustomException>(Custom, HttpStatusCode.BadRequest);
            }
            Logger.Debug("Method End");
        }

    }
}
