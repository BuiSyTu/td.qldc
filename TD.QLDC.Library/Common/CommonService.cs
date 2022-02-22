using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
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
    }
}
