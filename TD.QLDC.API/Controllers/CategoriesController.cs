using System.Web.Http;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.FilterModels;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;

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
        public IHttpActionResult GetCategories([FromUri] CategoryFilterModel filterModel)
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
            var category = _repository.GetById(id);

            if (category is null)
            {
                return NotFound();
            }

            _repository.Delete(category);
            return ApiNoContent();
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
