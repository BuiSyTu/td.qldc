using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.SharePoint;
using Microsoft.SharePoint.IdentityModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.QLDC.Library.ViewModels;

namespace TD.QLDC.Library.Services
{
    public interface IUserService
    {
        string CreateJWT(PayLoadJWT payload);
    }

    public class UserService : IUserService
    {
        private string secretJWT = "TanDan123!@#456789";

        public string CreateJWT(PayLoadJWT payload)
        {
            if (string.IsNullOrEmpty(secretJWT))
                secretJWT = ConfigurationManager.AppSettings["secretJWT"] != null ? ConfigurationManager.AppSettings["secretJWT"] : "TanDan123!@#456789";
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(payload, secretJWT);
            return token;
        }

        public string GetUserTokenKey(string user, string pass, string tokenDevice)
        {
            user = user.ToLower();

            PayLoadJWT payLoadJWT = new()
            {
                Iat = (int)DateTimeOffset.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                Exp = (int)DateTimeOffset.UtcNow.AddYears(3).Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                User = user
            };


            string urlRoot = SPContext.Current.Site.RootWeb.Url;
            bool isLoginSuccess = SPClaimsUtility.AuthenticateFormsUser(new Uri(urlRoot), user, pass);

            if (!isLoginSuccess) return null;

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (SPSite oSite = new SPSite(urlRoot + "/sites/qldc"))
                {
                    SPWeb rootWeb = oSite.RootWeb;
                    SPList lstUser = rootWeb.Lists["Users"];

                    var query = new SPQuery()
                    {
                        Query = "<Where><Contains><FieldRef Name='UserAccount' /><Value Type='Text'>" + user + "</Value></Contains></Where>",
                        RowLimit = 1
                    };
                    var spItems = lstUser.GetItems(query);
                    if (spItems != null && spItems.Count > 0)
                    {
                        payLoadJWT.Permissions = spItems[0]["Permissions"].ToString();
                    }
                }
            });

            return CreateJWT(payLoadJWT);
        }

        private SPListItem GetByAccountName(SPList listUserProfiles, string account)
        {
            try
            {
                var query = new SPQuery()
                {
                    Query = "<Where><Eq><FieldRef Name='Account'/><Value Type='Text'>" + account + "</Value></Eq></Where>",
                    RowLimit = 1
                };

                var spItems = listUserProfiles.GetItems(query);

                if (spItems != null && spItems.Count > 0)
                {
                    return spItems[0];
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
