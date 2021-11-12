using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Http;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.SharePoint;


namespace TD.QLDC.API.Controllers
{
    public sealed class HoKhausController : TDApiController
    {
        private readonly IHoKhauRepository _HoKhauRepository;
        public HoKhausController(IHoKhauRepository HoKhauRepository)
        {
            _HoKhauRepository = HoKhauRepository;

        }
  
        [Route("QLDCapi/HoKhaus/CheckMa/{shk}")]
        [HttpGet]
        public IHttpActionResult CheckMa(string shk)
        {
            var data = _HoKhauRepository.CheckMa(shk);
            return ApiOk(data);
        }

        [Route("QLDCapi/HoKhaus/GetSHKByID/{id:int:min(1)}")]
        [HttpGet]
        public IHttpActionResult GetSHKByID(int id)
        {
            var data = _HoKhauRepository.GetSHKByID(id);
            return ApiOk(data);
        }

        [Route("QLDCapi/HoKhaus")]
        [HttpGet]
        public IHttpActionResult GetHoKhaus(int skip = 0, int top = 100, string q = null, string orderBy = null, bool count = false)
        {
            ICollection<string> collecionOrderBy = null;
            if (!string.IsNullOrEmpty(orderBy))
            {
                collecionOrderBy = new Regex(@"\s*,\s*").Split(orderBy);
            }
            var data = _HoKhauRepository.Get(skip, top, q, collecionOrderBy, null);
            return ApiOk(data,
                        null,
                        (result) =>
                        {
                            if (count)
                            {
                                result.ExtensionData["count"] = skip == 0 && top == 0
                                    ? data.Count
                                    : _HoKhauRepository.Count(q, collecionOrderBy, null);
                            }
                        });
        }

        [Route("QLDCapi/HoKhaus/{id:int:min(1)}")]
        [HttpGet]
        public IHttpActionResult GetHoKhau(int id)
        {
            var HoKhau = _HoKhauRepository.GetById(id);
            if (HoKhau == null)
            {
                return ApiNotFound();
            }
            return ApiOk(HoKhau);
        }

        [Route("QLDCapi/HoKhaus/{id:int:min(1)}")]
        [HttpPut]
        public IHttpActionResult PutHoKhau(int id, HoKhau change)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequest(null, ModelState);
            }

            if (id != change.ID)
            {
                return ApiBadRequest();
            }
            _HoKhauRepository.Update(change);
            return ApiNoContent();
        }

        [Route("QLDCapi/HoKhaus")]
        [HttpPost]
        public IHttpActionResult PostHoKhau(HoKhau entity)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequest(null, ModelState);
            }
            var HoKhau = _HoKhauRepository.Add(entity);
            return ApiCreated(HoKhau);
        }
        
        [Route("QLDCapi/HoKhaus/{id:int:min(1)}")]
        [HttpDelete]
        public IHttpActionResult DeleteHoKhau(int id)
        {
            var HoKhau = _HoKhauRepository.Delete(id);
            return ApiOk();
        }


        [Route("QLDCapi/HoKhaus/count")]
        [HttpGet]
        public IHttpActionResult GetCountHoKhau()
        {
            var count = _HoKhauRepository.Count();
            if (count == 0)
            {
                return ApiNotFound();
            }
            return ApiOk(count);
        }
    }
}
