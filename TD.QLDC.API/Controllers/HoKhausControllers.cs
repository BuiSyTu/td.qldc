﻿using System.Web.Http;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.FilterModels;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;
using TD.QLDC.Library.Services.Interfaces;

namespace TD.QLDC.API.Controllers
{
    public class HoKhausController : TDApiController
    {
        private readonly IHoKhauRepository _repository;
        private readonly IHoKhauService _service;

        public HoKhausController(IHoKhauRepository repository, IHoKhauService service)
        {
            _repository = repository;
            _service = service;
        }

        [Route("QLDCapi/HoKhaus")]
        [HttpGet]
        public IHttpActionResult GetHoKhaus([FromUri] HoKhauFilterModel filterModel)
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

        [Route("QLDCapi/HoKhaus/{id:int:min(1)}")]
        [HttpGet]
        public IHttpActionResult GetHoKhau(int id)
        {
            var HoKhau = _repository.GetById(id);
            if (HoKhau == null)
            {
                return ApiNotFound();
            }
            return ApiOk(HoKhau);
        }

        [Route("QLDCapi/HoKhaus/NhanKhauCCCD/{cccd}")]
        [HttpGet]
        public IHttpActionResult GetHoKhauByNhanKhauCccd(string cccd)
        {
            var HoKhau = _repository.GetSingleByNhanKhauCccd(cccd);
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
            _repository.Update(change);
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
            var HoKhau = _repository.Add(entity);
            return ApiCreated(HoKhau);
        }
        
        [Route("QLDCapi/HoKhaus/{id:int:min(1)}")]
        [HttpDelete]
        public IHttpActionResult DeleteHoKhau(int id)
        {
            var hoKhau = _repository.GetById(id);

            if (hoKhau is null)
            {
                return NotFound();
            }

            _repository.Delete(hoKhau);
            return ApiNoContent();
        }


        [Route("QLDCapi/HoKhaus/count")]
        [HttpGet]
        public IHttpActionResult GetCountHoKhau([FromUri]HoKhauFilterModel filterModel)
        {
            var count = _repository.Count(filterModel);
            return ApiOk(count);
        }

        [Route("QLDCapi/HoKhaus/currentTree")]
        [HttpGet]
        public IHttpActionResult GetCurrentTree()
        {
            var result = _service.GetCurrentTree();
            return ApiOk(result);
        }
    }
}
