using System.Web.Http;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.FilterModels;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;

namespace TD.QLDC.API.Controllers
{
    public class NhomDanhMucsController : TDApiController
    {
        private readonly INhomDanhMucRepository _repository;

        public NhomDanhMucsController(INhomDanhMucRepository repository)
        {
            _repository = repository;
        }

        [Route("QLDCapi/NhomDanhMucs")]
        [HttpGet]
        public IHttpActionResult GetNhomDanhMucs([FromUri] NhomDanhMucFilterModel filterModel)
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

        [Route("QLDCapi/NhomDanhMucs/{id:int:min(1)}")]
        [HttpGet]
        public IHttpActionResult GetNhomDanhMuc(int id)
        {
            var NhomDanhMuc = _repository.GetById(id);
            if (NhomDanhMuc == null)
            {
                return ApiNotFound();
            }
            return ApiOk(NhomDanhMuc);
        }

        [Route("QLDCapi/NhomDanhMucs/{id:int:min(1)}")]
        [HttpPut]
        public IHttpActionResult PutNhomDanhMuc(int id, NhomDanhMuc change)
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

        [Route("QLDCapi/NhomDanhMucs")]
        [HttpPost]
        public IHttpActionResult PostNhomDanhMuc(NhomDanhMuc entity)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequest(null, ModelState);
            }
            var NhomDanhMuc = _repository.Add(entity);
            return ApiCreated(NhomDanhMuc);
        }

        [Route("QLDCapi/NhomDanhMucs/{id:int:min(1)}")]
        [HttpDelete]
        public IHttpActionResult DeleteNhomDanhMuc(int id)
        {
            var nhomDanhMuc = _repository.GetById(id);

            if (nhomDanhMuc is null)
            {
                return NotFound();
            }

            _repository.Delete(nhomDanhMuc);
            return ApiOk();
        }

        [Route("QLDCapi/NhomDanhMucs/count")]
        [HttpGet]
        public IHttpActionResult GetCountNhomDanhMuc()
        {
            var count = _repository.Count();
            if (count == 0)
            {
                return ApiNotFound();
            }
            return ApiOk(count);
        }
    }
}
