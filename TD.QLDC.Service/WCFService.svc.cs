using System.IO;
using System.ServiceModel.Activation;
using TD.QLDC.Service.Common;

namespace TD.QLDC.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public partial class WCFService : WCFController, IWCFService
    {
        public Stream HelloWorld()
        {
            return Ok("Hello world");
        }
    }
}
