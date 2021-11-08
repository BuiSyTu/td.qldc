using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace TD.QLDC.Features.QLDCApi
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("f1a4c083-402f-491c-914d-14472f03e4bc")]
    public class QLDCApiEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPDiagnosticsService.Local.WriteTrace(0,
                                                  new SPDiagnosticsCategory(
                                                      "Tandan.QLDC.API",
                                                      TraceSeverity.Medium,
                                                      EventSeverity.Information),
                                                  TraceSeverity.Medium,
                                                  string.Format(
                                                      "Feature: Registering HTTPModule for Api"),
                                                  null);
            RegisterHttpModule(properties);
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPDiagnosticsService.Local.WriteTrace(0,
                                                  new SPDiagnosticsCategory(
                                                      "Tandan.QLDC.API",
                                                      TraceSeverity.Medium,
                                                      EventSeverity.Information),
                                                  TraceSeverity.Medium,
                                                  string.Format("Feature: Removing HTTPModule for Api"),
                                                  null);
            UnregisterHttpModule(properties);
        }


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}

        private void RegisterHttpModule(SPFeatureReceiverProperties properties)
        {
            SPWebApplication webApp = properties.Feature.Parent as SPWebApplication;
            SPWebConfigModification webConfigModification = CreateWebModificationObject();

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                webApp.WebConfigModifications.Add(webConfigModification);
                webApp.Update();
                webApp.WebService.ApplyWebConfigModifications();
            });
        }

        /// <summary>
        /// Create the SPWebConfigModification object for the signalr module
        /// </summary>
        /// <returns>SPWebConfigModification object for the http module to the web.config</returns>
        private SPWebConfigModification CreateWebModificationObject()
        {
            string name = string.Format("add[@name=\"{0}\"]", "QLDCApiModule");
            string xpath = "/configuration/ApiIntegrationConfigs/ApiIntegrations";

            SPWebConfigModification webConfigModification = new SPWebConfigModification(name, xpath);

            webConfigModification.Owner = "Tandan.QLDC.API";
            webConfigModification.Sequence = 0;
            webConfigModification.Type = SPWebConfigModification.SPWebConfigModificationType.EnsureChildNode;

            //reflection safe
            webConfigModification.Value = String.Format("<add name=\"{0}\" type=\"{1}\" />", "QLDCApiModule",
                                                        "TD.QLDC.API.Integration.QLDCApiModule, TD.QLDC.API, Version=1.0.0.0, Culture=neutral, PublicKeyToken=38fe38121aecde62");
            return webConfigModification;
        }

        private void UnregisterHttpModule(SPFeatureReceiverProperties properties)
        {
            SPWebConfigModification delwebConfigModification = CreateWebModificationObject();
            SPWebApplication webApp = properties.Feature.Parent as SPWebApplication;

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                //SPWebService contentService = properties.Definition.Farm.Services.GetValue<SPWebService>();

                int numberOfModifications = webApp.WebConfigModifications.Count;

                //Iterate over all WebConfigModification and delete only those we have created
                for (int i = numberOfModifications - 1; i >= 0; i--)
                {
                    SPWebConfigModification currentModifiction = webApp.WebConfigModifications[i];

                    if (currentModifiction.Owner == delwebConfigModification.Owner && currentModifiction.Name == delwebConfigModification.Name)
                    {
                        webApp.WebConfigModifications.Remove(currentModifiction);
                    }
                }

                //Update only if we have something deleted
                if (numberOfModifications > webApp.WebConfigModifications.Count)
                {
                    webApp.Update();
                    webApp.WebService.ApplyWebConfigModifications();
                }

            });

        }
    }
}
