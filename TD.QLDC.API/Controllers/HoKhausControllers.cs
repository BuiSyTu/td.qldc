using System.Web.Http;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;

namespace TD.QLDC.API.Controllers
{
    public class HoKhausController : TDApiController
    {
        private readonly IHoKhauRepository _repository;
        public HoKhausController(IHoKhauRepository repository)
        {
            _repository = repository;

        }
  
        [Route("QLDCapi/HoKhaus/CheckMa/{shk}")]
        [HttpGet]
        public IHttpActionResult CheckMa(string shk)
        {
            var data = _repository.CheckMa(shk);
            return ApiOk(data);
        }

        [Route("QLDCapi/HoKhaus")]
        [HttpGet]
        public IHttpActionResult GetHoKhaus(
            int skip = 0,
            int top = 100,
            string q = null,
            string orderBy = null,
            string includes = null,
            bool count = false
        )
        {
            var data = _repository.Get(skip, top, q, orderBy, includes);

            return ApiOk(data,
                        null,
                        (result) =>
                        {
                            if (count)
                            {
                                result.ExtensionData["count"] = skip == 0 && top == 0
                                    ? data.Count
                                    : _repository.Count(q);
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
        public IHttpActionResult GetCountHoKhau()
        {
            var count = _repository.Count();
            return ApiOk(count);
        }
    }
}
