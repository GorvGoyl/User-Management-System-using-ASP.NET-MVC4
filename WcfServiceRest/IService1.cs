﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Models;
namespace WcfServiceRest
{
    // [assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.xml", Watch = true)]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {


        [OperationContract]
        [WebGet(
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.WrappedRequest,
                    UriTemplate = "RetrieveAll"
                   )]
        List<User> RetrieveAll();

        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.WrappedRequest,
                    UriTemplate = "Edit"
                   )]
        User Edit(string guid);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.WrappedRequest,
                    UriTemplate = "Delete"
                    )]
        void Delete(string guid);

        [OperationContract]
        [WebInvoke( Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.WrappedRequest,
                    UriTemplate = "Update"
                    )]
        void Update(List<string> userData);

        [OperationContract]
        [WebInvoke( Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.WrappedRequest,
                    UriTemplate = "AddUser"
                    )]
        void AddUser(List<string> userData);

     
    }

    [DataContract]
    public class MyCustomException
    {
        public MyCustomException(string errorInfo,string errorDetail)
        {
            ErrorDetail = errorDetail;
            ErrorInfo = errorInfo;
        }

        [DataMember]
        public string ErrorInfo { get; set; }

        [DataMember]
        public string ErrorDetail { get; set; }

    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class Users
    //{
    //    [DataMember]
    //    public string GUID { get; set; }
    //    [DataMember]
    //    public string Name { get; set; }
    //    [DataMember]
    //    public string Phone { get; set; }
    //    [DataMember]
    //    public string City { get; set; }
    //    [DataMember]
    //    public string DOB { get; set; }
    //    [DataMember]
    //    public string EMail { get; set; }
    //}
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
