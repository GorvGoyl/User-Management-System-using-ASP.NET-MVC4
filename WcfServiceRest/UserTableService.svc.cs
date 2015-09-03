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

        public void Create(User user)
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
                UserCrudOperations.Create(user);
            }
            catch (Exception)
            {
                MyCustomException Custom = new MyCustomException("DataBase Error", "Can't add the data to DataBase");
                throw new WebFaultException<MyCustomException>(Custom, HttpStatusCode.BadRequest);
            }
            Logger.Debug("Method End");
        }

        public User RetrieveUser(User user)
        {
            Logger.Debug("Method Start");
   
            User UserData;
            try
            {
                UserData = UserCrudOperations.RetrieveUser(user);
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

        public List<User> Retrieve()
        {
            Logger.Debug("Method Start");
            List<User> UsersList;

            try
            {
                UsersList = UserCrudOperations.Retrieve();
            }
            catch (Exception ex)
            {
                MyCustomException Custom = new MyCustomException(ex.Message,JsonConvert.SerializeObject(ex));
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

        public void Update(User user)
        {
            Logger.Debug("Method Start");
            
            try
            {
                UserCrudOperations.Update(user);
            }
            catch (Exception)
            {
                MyCustomException Custom = new MyCustomException("DataBase Error", "Can't update the data to DataBase");
                throw new WebFaultException<MyCustomException>(Custom, HttpStatusCode.BadRequest);
            }
            Logger.Debug("Method End");

        }  

        public void Delete(User user)
        {
            Logger.Debug("Method Start");

            try
            {
                UserCrudOperations.Delete(user);
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
