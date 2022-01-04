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
    public class NhomDanhMucsController : TDApiController
    {
        private readonly INhomDanhMucRepository _repository;

        public NhomDanhMucsController(INhomDanhMucRepository repository)
        {
            _repository = repository;
        }

        [Route("QLDCapi/NhomDanhMucs")]
        [HttpGet]
        public IHttpActionResult GetNhomDanhMucs(int skip = 0, int top = 100,
            string q = null, string orderBy = null, bool count = false,
            string include = null)
        {
            ICollection<string> collecionInclude = null;
            if (!string.IsNullOrEmpty(include))
            {
                collecionInclude = new Regex(@"\s*,\s*").Split(include);
            }
            ICollection<string> collecionOrderBy = null;
            if (!string.IsNullOrEmpty(orderBy))
            {
                collecionOrderBy = new Regex(@"\s*,\s*").Split(orderBy);
            }
            var data = _repository.Get(skip, top, q, collecionOrderBy, collecionInclude);
            return ApiOk(data,
                        null,
                        (result) =>
                        {
                            if (count)
                            {
                                result.ExtensionData["count"] = skip == 0 && top == 0
                                    ? data.Count
                                    : _repository.Count(q, collecionOrderBy, collecionInclude);
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
            var NhomDanhMuc = _repository.Delete(id);
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
