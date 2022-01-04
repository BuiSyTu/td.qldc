using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Core.UserProfiles.Controllers;
using TD.Core.UserProfiles.Models;

namespace TD.QLDC.Library.Services
{
    public class AreaService
    {
        public static string GetCurrentAreaCode()
        {
            string urlRoot = SPContext.Current.Site.RootWeb.Url;
            using (SPSite mySite = new SPSite(urlRoot))
            {
                var webApp = mySite.WebApplication;
                var zone = mySite.Zone;

                UserProfileController userProfileCtrlr = new UserProfileController(webApp, zone);
                UserProfile userProfile = userProfileCtrlr.GetByCurrentUser();
                var currentAreaCode = userProfile.AreaCode;

                return currentAreaCode;
            }
        }
    }
}
