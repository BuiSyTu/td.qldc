using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using TD.QLDC.Service.ViewModels;

namespace TD.QLDC.Service
{
    [ServiceContract]
    public interface IWCFService
    {
        [WebGet(UriTemplate = "helloworld", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Stream HelloWorld();

        [WebInvoke(
            Method = "POST",
            UriTemplate = "CheckValidNhanKhau",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        Stream CheckValidNhanKhau(CheckValidNhanKhauInput input);

        [WebGet(UriTemplate = "hokhaus/nhankhaucccd/{cccd}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Stream GetInformation(string cccd =  null);

        #region old
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        APIResult GetUserTokenKey(string user, string pass, string tokenDevice);

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        APIResult GetTokenKey(string user, string pass, string tokenDevice);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/CheckVerificationCode/{user}/{code}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        APIResult CheckVerificationCode(string user, string code);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        APIResult CheckUserRegister(string user);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        APIResult CreateUserRegister(string user, string pass);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/LayNhanKhauTheoMaDinhDanh/{code}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        APIResult LayNhanKhauTheoMaDinhDanh(string code);

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        APIResult GetTokenDevices(string token);

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        APIResult LogoutUser(string token, string tokenDevice);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        APIResult CreateNewUser(string account, string passWord, string address, string avatar, string birthday, string email, string fullName, string phone, string sex, string areaCode);
        
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        APIResult CreateNhanKhau(string hoten, string hktt, string birthday, string phone, string sex, string mqh, string nghenghiep, string dantoc);
        #endregion
    }
}
