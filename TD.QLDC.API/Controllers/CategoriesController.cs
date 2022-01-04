using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Http;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories;

namespace TD.QLDC.API.Controllers
{
    public class CategoriesController : TDApiController
    {
        private readonly ICategoryRepository _repository;

        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [Route("QLDCapi/categories")]
        [HttpGet]
        public IHttpActionResult GetCategories(
            int skip = 0,
            int top = 100,
            string q = null,
            string orderBy = null,
            bool count = false,
            string includes = null,
            int? nhomId  = null,
            bool? active = null
        )
        {
            var data = _repository.Get(skip, top, q, orderBy, includes, nhomId, active);
            return ApiOk(data,
                        null,
                        (result) =>
                        {
                            if (count)
                            {
                                result.ExtensionData["count"] = skip == 0 && top == 0
                                    ? data.Count
                                    : _repository.Count(q, nhomId, active);
                            }
                        });
        }

        [Route("QLDCapi/categories/{id:int:min(1)}")]
        [HttpGet]
        public IHttpActionResult GetCategory(int id)
        {
            var Category = _repository.GetById(id);
            if (Category == null)
            {
                return ApiNotFound();
            }
            return ApiOk(Category);
        }

        [Route("QLDCapi/categories/{id:int:min(1)}")]
        [HttpPut]
        public IHttpActionResult PutCategory(int id, Category change)
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

        [Route("QLDCapi/categories")]
        [HttpPost]
        public IHttpActionResult PostCategory(Category entity)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequest(null, ModelState);
            }
            var Category = _repository.Add(entity);
            return ApiCreated(Category);
        }

        [Route("QLDCapi/categories/{id:int:min(1)}")]
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            var Category = _repository.Delete(id);
            return ApiOk();
        }

        [Route("QLDCapi/categories/count")]
        [HttpGet]
        public IHttpActionResult GetCountCategory()
        {
            var count = _repository.Count();
            return ApiOk(count);
        }
    }
}
