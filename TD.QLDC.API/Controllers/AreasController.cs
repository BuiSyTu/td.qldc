using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Http;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories;
using System.Linq;
using Newtonsoft.Json;

namespace TD.QLDC.API.Controllers
{
    public class AreasController : TDApiController
    {
        private readonly IAreaRepository _AreaRepository;

        public AreasController(IAreaRepository AreaRepository)
        {
            _AreaRepository = AreaRepository;
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
            var data = _AreaRepository.Get(skip, top, q, includes, orderBy, areaCode, type, parentCode);
            return ApiOk(data,
                        null,
                        (result) =>
                        {
                            if (count)
                            {
                                result.ExtensionData["count"] = skip == 0 && top == 0
                                    ? data.Count
                                    : _AreaRepository.Count(q, areaCode, type, parentCode);
                            }
                        });
        }

        [Route("QLDCapi/Areas/{id:int:min(1)}")]
        [HttpGet]
        public IHttpActionResult GetArea(int id)
        {
            var Area = _AreaRepository.GetById(id);
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
            var Area = _AreaRepository.GetSingleByCode(code);
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
            _AreaRepository.Update(change);
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
            var Area = _AreaRepository.Add(entity);
            return ApiCreated(Area);
        }

        [Route("QLDCapi/Areas/{id:int:min(1)}")]
        [HttpDelete]
        public IHttpActionResult DeleteArea(int id)
        {
            var area = _AreaRepository.GetById(id);

            _AreaRepository.Delete(area);
            return ApiOk();
        }

        [Route("QLDCapi/Areas/count")]
        [HttpGet]
        public IHttpActionResult GetCountArea()
        {
            var count = _AreaRepository.Count();
            return ApiOk(count);
        }
    }
}
