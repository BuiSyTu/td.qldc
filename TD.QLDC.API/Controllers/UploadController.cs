using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Services.Interfaces;

namespace TD.QLDC.API.Controllers
{
    public class UploadController : TDApiController
    {
        private readonly IUploadService _uploadService;

        public UploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [Route("QLDCapi/Upload/Bieu4")]
        [HttpPost]
        public async Task<IHttpActionResult> UploadBieu1()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            // Lấy 3 tham số sheet, rowStart, rowEnd
            int sheet = int.TryParse(HttpContext.Current.Request.Params["sheet"], out int sheetCV)
                ? sheetCV
                : 0;

            int rowStart = int.TryParse(HttpContext.Current.Request.Params["rowStart"], out int rowStartCV)
                ? rowStartCV
                : 0;

            int rowEnd = int.TryParse(HttpContext.Current.Request.Params["rowEnd"], out int rowEndCV)
                ? rowEndCV
                : 0;

            string maTinh = HttpContext.Current.Request.Params["maTinh"];
            string tenTinh = HttpContext.Current.Request.Params["tenTinh"];

            string maHuyen = HttpContext.Current.Request.Params["maHuyen"];
            string tenHuyen = HttpContext.Current.Request.Params["tenHuyen"];

            string maXa = HttpContext.Current.Request.Params["maXa"];
            string tenXa = HttpContext.Current.Request.Params["tenXa"];

            string maThon = HttpContext.Current.Request.Params["maThon"];
            string tenThon = HttpContext.Current.Request.Params["tenThon"];

            string maXom = HttpContext.Current.Request.Params["maXom"];
            string tenXom = HttpContext.Current.Request.Params["tenXom"];

            // Lấy file
            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            var file = provider.Contents[0];
            var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
            var buffer = await file.ReadAsByteArrayAsync();

            // Xử lý phần còn lại
            var count = _uploadService.UploadBieu4(
                buffer, sheet, rowStart, rowEnd,
                maTinh, tenTinh,
                maHuyen, tenHuyen,
                maXa, tenXa,
                maThon, tenThon,
                maXom, tenXom
            );

            return Ok(count);
        }
    }
}
