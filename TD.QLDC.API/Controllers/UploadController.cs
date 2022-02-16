using System;
using System.Collections.Generic;
using System.Linq;
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

        [Route("QLDCapi/Upload/Bieu1")]
        [HttpGet]
        public async Task<IHttpActionResult> UploadBieu1()
        {
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

            // Lấy file
            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            var file = provider.Contents[0];
            var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
            var buffer = await file.ReadAsByteArrayAsync();

            // Xử lý phần còn lại
            return Ok();

        }
    }
}
