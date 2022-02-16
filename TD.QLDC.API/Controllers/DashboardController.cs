using System.Web.Http;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Services;
using TD.QLDC.Library.Services.Interfaces;

namespace TD.QLDC.API.Controllers
{
    public class DashboardController : TDApiController
    {
        private readonly IDashboardService _service;

        public DashboardController(
            IDashboardService service
        )
        {
            _service = service;
        }

        [Route("qldcapi/dashboard/widget")]
        [HttpGet]
        public IHttpActionResult GetWidget()
        {
            var widget = _service.GetWidget();
            return ApiOk(widget);
        }

        [Route("qldcapi/dashboard/chart1")]
        [HttpGet]
        public IHttpActionResult GetChart1()
        {
            var widget = _service.GetChart1();
            return ApiOk(widget);
        }

        [Route("qldcapi/dashboard/chart2")]
        [HttpGet]
        public IHttpActionResult GetChart2()
        {
            var widget = _service.GetChart2();
            return ApiOk(widget);
        }
    }
}
