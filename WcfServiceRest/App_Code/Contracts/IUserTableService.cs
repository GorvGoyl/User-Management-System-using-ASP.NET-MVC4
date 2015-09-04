using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataObjects;
namespace WcfServiceRest
{

    [ServiceContract]
    public interface IUserTableService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.WrappedRequest,
                    UriTemplate = "Create"
                    )]
        void Create(User user);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.WrappedRequest,
                    UriTemplate = "RetrieveUser"
                   )]
        User RetrieveUser(User user);

        [OperationContract]
        [WebGet(
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.WrappedRequest,
                    UriTemplate = "Retrieve"
                   )]
        List<User> Retrieve();

        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.WrappedRequest,
                    UriTemplate = "Update"
                    )]
        void Update(User user);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.WrappedRequest,
                    UriTemplate = "Delete"
                    )]
        void Delete(User user);
    }

    [DataContract]
    public class CustomException
    {
        public CustomException(string errorInfo, string errorDetail)
        {
            ErrorDetail = errorDetail;
            ErrorInfo = errorInfo;
        }
        [DataMember]
        public string ErrorInfo { get; set; }
        [DataMember]
        public string ErrorDetail { get; set; }
    }

}
