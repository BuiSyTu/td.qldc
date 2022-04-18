using System.Web.Http;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.FilterModels;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;
using TD.QLDC.Library.Services.Interfaces;

namespace TD.QLDC.API.Controllers
{
    public class NhanKhausController : TDApiController
    {
        private readonly INhanKhauRepository _repository;
        private readonly INhanKhauService _service;

        public NhanKhausController(INhanKhauRepository repository, INhanKhauService service)
        {
            _repository = repository;
            _service = service;
        }

        [Route("QLDCapi/NhanKhaus")]
        [HttpGet]
        public IHttpActionResult GetNhanKhaus([FromUri] NhanKhauFilterModel filterModel)
        {

            var data = _repository.Get(filterModel);
            return ApiOk(data,
                        null,
                        (result) =>
                        {
                            if (filterModel.Count)
                            {
                                result.ExtensionData["count"] = filterModel.Skip == 0 && filterModel.Top == 0
                                    ? data.Count
                                    : _repository.Count(filterModel);
                            }
                        });
        }

        [Route("QLDCapi/NhanKhaus/{id:int:min(1)}")]
        [HttpGet]
        public IHttpActionResult GetNhanKhau(int id)
        {
            var NhanKhau = _repository.GetById(id);
            if (NhanKhau == null)
            {
                return ApiNotFound();
            }
            return ApiOk(NhanKhau);
        }

        [Route("QLDCapi/NhanKhaus/{id:int:min(1)}")]
        [HttpPut]
        public IHttpActionResult PutNhanKhau(int id, NhanKhau change)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequest(null, ModelState);
            }

            if (id != change.ID)
            {
                return ApiBadRequest();
            }
            _repository.Update(change);
            return ApiNoContent();
        }

        [Route("QLDCapi/NhanKhaus")]
        [HttpPost]
        public IHttpActionResult PostNhanKhau(NhanKhau entity)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequest(null, ModelState);
            }
            var NhanKhau = _repository.Add(entity);
            return ApiCreated(NhanKhau);
        }

        [Route("QLDCapi/NhanKhaus/{id:int:min(1)}")]
        [HttpDelete]
        public IHttpActionResult DeleteNhanKhau(int id)
        {
            var nhanKhau = _repository.GetById(id);

            if (nhanKhau is null)
            {
                return NotFound();
            }

            _repository.Delete(nhanKhau);
            return ApiNoContent();
        }

        [Route("QLDCapi/NhanKhaus/count")]
        [HttpGet]
        public IHttpActionResult GetCountNhanKhau([FromUri]NhanKhauFilterModel filterModel)
        {
            var count = _repository.Count(filterModel);
            if (count == 0)
            {
                return ApiNotFound();
            }
            return ApiOk(count);
        }

        [Route("QLDCapi/NhanKhaus/currentTree")]
        [HttpGet]
        public IHttpActionResult GetCurrentTree([FromUri] NhanKhauFilterModel filterModel)
        {
            var result = _service.GetCurrentTree(filterModel);
            return ApiOk(result);
        }
    }
}
