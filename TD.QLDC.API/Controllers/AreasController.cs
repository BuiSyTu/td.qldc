using System.Web.Http;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;

namespace TD.QLDC.API.Controllers
{
    public class AreasController : TDApiController
    {
        private readonly IAreaRepository _repository;

        public AreasController(IAreaRepository repository)
        {
            _repository = repository;
        }

        [Route("QLDCapi/Areas")]
        [HttpGet]
        public IHttpActionResult GetAreas(
            int skip = 0,
            int top = 100,
            string q = null,
            string orderBy = null,
            bool count = false,
            string includes = null,
            string areaCode = null,
            int? type = null,
            string parentCode = null)
        {
            var data = _repository.Get(skip, top, q, includes, orderBy, areaCode, type, parentCode);
            return ApiOk(data,
                        null,
                        (result) =>
                        {
                            if (count)
                            {
                                result.ExtensionData["count"] = skip == 0 && top == 0
                                    ? data.Count
                                    : _repository.Count(q, areaCode, type, parentCode);
                            }
                        });
        }

        [Route("QLDCapi/Areas/{id:int:min(1)}")]
        [HttpGet]
        public IHttpActionResult GetArea(int id)
        {
            var Area = _repository.GetById(id);
            if (Area == null)
            {
                return ApiNotFound();
            }
            return ApiOk(Area);
        }

        [Route("QLDCapi/Areas/code/{code}")]
        [HttpGet]
        public IHttpActionResult GetSingleByCode(string code)
        {
            var Area = _repository.GetSingleByCode(code);
            if (Area == null)
            {
                return ApiNotFound();
            }
            return ApiOk(Area);
        }

        [Route("QLDCapi/Areas/{id:int:min(1)}")]
        [HttpPut]
        public IHttpActionResult PutArea(int id, Area change)
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

        [Route("QLDCapi/Areas")]
        [HttpPost]
        public IHttpActionResult PostArea(Area entity)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequest(null, ModelState);
            }
            var Area = _repository.Add(entity);
            return ApiCreated(Area);
        }

        [Route("QLDCapi/Areas/{id:int:min(1)}")]
        [HttpDelete]
        public IHttpActionResult DeleteArea(int id)
        {
            var area = _repository.GetById(id);

            _repository.Delete(area);
            return ApiOk();
        }

        [Route("QLDCapi/Areas/count")]
        [HttpGet]
        public IHttpActionResult GetCountArea()
        {
            var count = _repository.Count();
            return ApiOk(count);
        }
    }
}
