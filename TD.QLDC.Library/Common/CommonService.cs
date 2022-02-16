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
    }
}
