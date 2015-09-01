using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BusinessAccessLayer;
using Models;
using Newtonsoft.Json;
using System.Net;
namespace WcfServiceRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public  List<User> RetrieveAll()
        {
            Logger.Debug("Method Start");
            List<User>  UserData = BusinesLayerCode.Retrieve();

            Logger.Debug("Method End");
            return UserData;
        }


        public void AddUser(List<string> userData)
        {
            Logger.Debug("Method Start");
            Logger.Debug(userData);
            BusinesLayerCode.AddUser(userData);
            Logger.Debug("Method End");
        }
        public void Update(List<string> userData)
        {
            Logger.Debug("Method Start");
            Logger.Debug(userData);
            BusinesLayerCode.Update(userData);
            Logger.Debug("Method End");

        }

        public  User Edit(string guid)
        {
            Logger.Debug("Method Start");
            Logger.Debug(guid);
            User UserData;
            try
            {
                if (!string.IsNullOrEmpty(guid))
                {
                    MyCustomException Custom = new MyCustomException("Guid not found","The guid to retrieve user is not present");
                    throw new WebFaultException<MyCustomException>(Custom,HttpStatusCode.NotFound);
                }
                UserData = BusinesLayerCode.Edit(guid);
            }
            catch (WebException exception)
            {
                throw exception;
            }
            Logger.Debug("Method End");
            return UserData;
        }
        public void Delete(string guid)
        {
            Logger.Debug("Method Start");
            Logger.Debug(guid);
            BusinesLayerCode.DeleteUser(guid);
            Logger.Debug("Method End");
        }
      

       

    }
}
