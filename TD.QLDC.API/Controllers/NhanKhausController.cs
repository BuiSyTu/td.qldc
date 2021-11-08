﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Http;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories;
using System.Linq;
using Newtonsoft.Json;

namespace TD.QLDC.API.Controllers
{
    public sealed class NhanKhausController : TDApiController
    {
        private readonly INhanKhauRepository _NhanKhauRepository;

        public NhanKhausController(INhanKhauRepository NhanKhauRepository)
        {
            _NhanKhauRepository = NhanKhauRepository;
        }

        
        [Route("QLDCapi/NhanKhaus/UpdateTheoSHK")]
        [HttpGet]
        public IHttpActionResult UpdateTheoSHK(string shkc, string shk)
        {
            var data = _NhanKhauRepository.UpdateTheoSHK(shkc, shk);
            return ApiOk(data);
        }
        // GET: QLDCapi/NhanKhaus
        // [Route("QLDCapi/NhanKhaus")]
        [ActionName("Index")]
        [HttpGet]
        public IHttpActionResult GetNhanKhaus(int skip = 0, int top = 100,
            string q = null, string orderBy = null, bool count = false,
            string include = null, string shk = null)
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
            var data = _NhanKhauRepository.Get(
                skip, top, q, collecionOrderBy, collecionInclude, shk);
            return ApiOk(data,
                        null,
                        (result) =>
                        {
                            if (count)
                            {
                                result.ExtensionData["count"] = skip == 0 && top == 0
                                    ? data.Count
                                    : _NhanKhauRepository.Count(q, collecionOrderBy, collecionInclude, shk);
                            }
                        });
        }

        [Route("QLDCapi/NhanKhaus/GetBySoHoKhau/{SoHoKhau}")]
        [HttpGet]
        public IHttpActionResult GetBySoHoKhau(string SoHoKhau)
        {
            var NhanKhau = _NhanKhauRepository.GetBySoHoKhau(SoHoKhau);
            return ApiOk(NhanKhau);
        }

        // GET: QLDCapi/NhanKhaus/5
        [Route("QLDCapi/NhanKhaus/{id:int:min(1)}")]
        [HttpGet]
        public IHttpActionResult GetNhanKhau(int id)
        {
            var NhanKhau = _NhanKhauRepository.GetById(id);
            if (NhanKhau == null)
            {
                return ApiNotFound();
            }
            return ApiOk(NhanKhau);
        }

        // PUT: QLDCapi/NhanKhaus/5
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
            _NhanKhauRepository.Update(change);
            return ApiNoContent();
        }

        // POST: QLDCapi/NhanKhaus
        // [Route("QLDCapi/NhanKhaus")]
        [ActionName("Index")]
        [HttpPost]
        public IHttpActionResult PostNhanKhau(NhanKhau entity)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequest(null, ModelState);
            }
            var NhanKhau = _NhanKhauRepository.Add(entity);
            return ApiCreated(NhanKhau);
        }

        // DELETE: QLDCapi/NhanKhaus/5
        [Route("QLDCapi/NhanKhaus/{id:int:min(1)}")]
        [HttpDelete]
        public IHttpActionResult DeleteNhanKhau(int id)
        {
            var NhanKhau = _NhanKhauRepository.Delete(id);
            return ApiOk();
        }

        // GET: QLDCapi/NhanKhaus/count
        [Route("QLDCapi/NhanKhaus/count")]
        [HttpGet]
        public IHttpActionResult GetCountNhanKhau()
        {
            var count = _NhanKhauRepository.Count();
            if (count == 0)
            {
                return ApiNotFound();
            }
            return ApiOk(count);
        }
    }
}
