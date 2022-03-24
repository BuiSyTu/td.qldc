using Newtonsoft.Json;
using System;
using System.IO;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;
using TD.QLDC.Library.Services.Interfaces;
using TD.QLDC.Service.Common;
using TD.QLDC.Service.ViewModels;
using Unity;

namespace TD.QLDC.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public partial class WCFService : WCFController, IWCFService
    {
        private readonly IUnityContainer _unityContainer;
        private readonly INhanKhauRepository _nhanKhauRepository;
        private readonly IHoKhauRepository _hoKhauRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAreaRepository _areaRepository;

        private readonly INhanKhauService _nhanKhauService;

        public WCFService()
        {
            _unityContainer = new UnityContainer().EnableDiagnostic();
            var integration = new Integration();
            integration.ConfigureContainer(_unityContainer);

            _nhanKhauRepository = _unityContainer.Resolve<INhanKhauRepository>();
            _hoKhauRepository = _unityContainer.Resolve<IHoKhauRepository>();
            _accountRepository  = _unityContainer.Resolve<IAccountRepository>();
            _areaRepository = _unityContainer.Resolve<IAreaRepository>();

            _nhanKhauService = _unityContainer.Resolve<INhanKhauService>();
        }

        public Stream CheckValidNhanKhau(CheckValidNhanKhauInput input)
        {
            var isValid = _nhanKhauRepository.CheckExist(
                hoTen: input.HoTen,
                cCCD: input.CCCD,
                ngaySinh: input.NgaySinh
            );
            return ApiOk(isValid);
        }

        public Stream GetAreaByCodes(string codes)
        {
            var data = _areaRepository.GetByCodes(codes);
            return ApiOk(data);
        }

        public Stream GetInformation(string cccd = null)
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            System.Net.WebHeaderCollection headers = request.Headers;

            bool login = false;
            if (headers["userTokenKey"] != null)
            {
                login = CheckLogin(headers["userTokenKey"]);
            }
            if (!login) return Forbidden();

            var hoKhau = _hoKhauRepository.GetSingleByNhanKhauCccd(cccd);
            return ApiOk(hoKhau);
        }

        public Stream GetNhanKhauByCccd(string cccd = null, string includes = null)
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            System.Net.WebHeaderCollection headers = request.Headers;

            bool login = false;
            if (headers["userTokenKey"] != null)
            {
                login = CheckLogin(headers["userTokenKey"]);
            }
            if (!login) return Forbidden();

            var nhanKhau = _nhanKhauService.GetByCccd(cccd, includes);
            return ApiOk(nhanKhau);
        }

        public Stream HelloWorld()
        {
            return ApiOk("Hello world");
        }

        public Stream Login(string username, string password)
        {
            var success = _accountRepository.Login(username, password);
            if (!success) return Unauthorized();

            var (token, payloadJWT) = GetToken(username, password);

            var response = HttpContext.Current.Response;
            response.Cookies.Remove("token");
            response.Cookies.Add(new HttpCookie("token", token));
            response.Cookies.Add(new HttpCookie("expiredTime", payloadJWT.exp.ToString()));

            return ApiOk(new
            {
                token,
                expiredTime = payloadJWT.exp.ToString()
            });
        }

        public Stream Logout()
        {
            var response = HttpContext.Current.Response;
            response.Cookies.Remove("token");
            return NoContent();
        }

        public Stream Register(string name, string username, string password)
        {
            Account account = _accountRepository.Register(name, username, password);
            return ApiOk(account);
        }

        private bool CheckLogin(string token)
        {
            string payload = APICommon.ValidateJWT(token);
            PayloadJWT payloadJWT = JsonConvert.DeserializeObject<PayloadJWT>(payload);
            string user = payloadJWT.context.user.userName;
            string pass = APICommon.doDecryptAES(payloadJWT.hashpwd);
            return _accountRepository.Login(user, pass);
        }


        private (string, PayloadJWT) GetToken(string username, string password, string displayName = null)
        {
            Account account = null;

            if (string.IsNullOrEmpty(displayName))
            {
                account = _accountRepository.Get(username, password);
            }
            

            var payloadJWT = new PayloadJWT()
            {
                iat = (int)DateTimeOffset.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                exp = (int)DateTimeOffset.UtcNow.AddYears(3).Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                sub = username,
                hashpwd = APICommon.doEncryptAES(password),
                context = new UserContext()
                {
                    user = new UserAPI()
                    {
                        displayName = account.Name,
                        userName = username
                    }
                }
            };

            var token = APICommon.CreateJWT(payloadJWT);
            return (token, payloadJWT);
        }
    }
}
