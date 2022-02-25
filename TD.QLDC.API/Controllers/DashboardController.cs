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

        [Route("qldcapi/dashboard/hogiadinhtheoxom")]
        [HttpGet]
        public IHttpActionResult GetChartHoGiaDinhTheoXom()
        {
            var widget = _service.GetChartHoGiaDinhTheoXom();
            return ApiOk(widget);
        }

        [Route("qldcapi/dashboard/chart2")]
        [HttpGet]
        public IHttpActionResult GetChart2()
        {
            var widget = _service.GetChart2();
            return ApiOk(widget);
        }

        [Route("qldcapi/dashboard/nhankhautheoxom")]
        [HttpGet]
        public IHttpActionResult GetChartNhanKhauTheoXom()
        {
            var widget = _service.GetChartNhanKhauTheoXom();
            return ApiOk(widget);
        }

        [Route("qldcapi/dashboard/dantoc")]
        [HttpGet]
        public IHttpActionResult GetChartDanToc()
        {
            var widget = _service.GetChartDanToc();
            return ApiOk(widget);
        }

        [Route("qldcapi/dashboard/tongiao")]
        [HttpGet]
        public IHttpActionResult GetChartTonGiao()
        {
            var widget = _service.GetChartTonGiao();
            return ApiOk(widget);
        }

        [Route("qldcapi/dashboard/nganhnghelaodong")]
        [HttpGet]
        public IHttpActionResult GetChartNganhNgheLaoDong()
        {
            var widget = _service.GetChartNganhNgheLaoDong();
            return ApiOk(widget);
        }

        [Route("qldcapi/dashboard/trinhdohocvan")]
        [HttpGet]
        public IHttpActionResult GetChartTrinhDoHocVan()
        {
            var widget = _service.GetChartTrinhDoHocVan();
            return ApiOk(widget);
        }

        [Route("qldcapi/dashboard/gioitinh")]
        [HttpGet]
        public IHttpActionResult GetChartGioiTinh()
        {
            var widget = _service.GetChartGioiTinh();
            return ApiOk(widget);
        }

        [Route("qldcapi/dashboard/dotuoi")]
        [HttpGet]
        public IHttpActionResult GetChartDoTuoi()
        {
            var widget = _service.GetChartDoTuoi();
            return ApiOk(widget);
        }
    }
}
