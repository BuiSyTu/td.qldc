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
    public class NhanKhausController : TDApiController
    {
        private readonly INhanKhauRepository _repository;

        public NhanKhausController(INhanKhauRepository repository)
        {
            _repository = repository;
        }

        [Route("QLDCapi/NhanKhaus")]
        [HttpGet]
        public IHttpActionResult GetNhanKhaus(
            int skip = 0,
            int top = 100,
            string q = null,
            string orderBy = null,
            bool count = false,
            string includes = null,
            string shk = null,
            int? hoKhauId = null)
        {

            var data = _repository.Get(skip, top, q, orderBy, includes, shk, hoKhauId);
            return ApiOk(data,
                        null,
                        (result) =>
                        {
                            if (count)
                            {
                                result.ExtensionData["count"] = skip == 0 && top == 0
                                    ? data.Count
                                    : _repository.Count(q, shk, hoKhauId);
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
            var NhanKhau = _repository.Delete(id);
            return ApiOk();
        }

        [Route("QLDCapi/NhanKhaus/count")]
        [HttpGet]
        public IHttpActionResult GetCountNhanKhau()
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
