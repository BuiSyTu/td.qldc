using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Text;
using TD.Core.UserProfiles.Controllers;
using TD.Core.UserProfiles.Models;

namespace TD.QLDC.Library.Common
{
    public class CommonService
    {
        public static string GetCurrentAreaCode()
        {
            string urlRoot = SPContext.Current.Site.RootWeb.Url;
            using SPSite mySite = new(urlRoot);
            SPWebApplication webApp = mySite.WebApplication;
            SPUrlZone zone = mySite.Zone;

            UserProfileController userProfileCtrlr = new UserProfileController(webApp, zone);
            UserProfile userProfile = userProfileCtrlr.GetByCurrentUser();
            string currentAreaCode = userProfile.AreaCode;

            return currentAreaCode;
        }

        public static int GhiChuBieu4ToDMQuanHeID(string ghiChuBieu4)
        {
            return ghiChuBieu4.ToUpper() switch
            {
                "CH" => 25,
                "CHỦ HỘ" => 25,
                "VỢ" => 41,
                "CHỒNG" => 42,
                "CON" => 43,
                "CHA" => 44,
                "BỐ" => 44,
                "MẸ" => 45,
                "ANH" => 58,
                "CHỊ" => 59,
                "EM" => 60,
                "CHÁU" => 81,
                "CON DÂU" => 82,
                "CON RỂ" => 83,
                _ => 0
            };
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
