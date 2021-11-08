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
    public sealed class CategoriesController : TDApiController
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: QLDCapi/categories
        // [Route("QLDCapi/categories")]
        [ActionName("Index")]
        [HttpGet]
        public IHttpActionResult GetCategories(int skip = 0, int top = 100,
            string q = null, string orderBy = null, bool count = false,
            string include = null, int? nhomid  = null, bool? active = null)
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
            var data = _categoryRepository.Get(skip, top, q, collecionOrderBy, collecionInclude, nhomid, active);
            return ApiOk(data,
                        null,
                        (result) =>
                        {
                            if (count)
                            {
                                result.ExtensionData["count"] = skip == 0 && top == 0
                                    ? data.Count
                                    : _categoryRepository.Count(q, collecionOrderBy, collecionInclude, nhomid, active);
                            }
                        });
        }

        //[Route("QLDCapi/Catories/GetByNhomID/{NhomID}")]
        //[HttpGet]
        //public IHttpActionResult GetByNhomID(int NhomID)
        //{
        //    var DanhMuc = _categoryRepository.GetByNhomID(NhomID);
        //    return ApiOk(DanhMuc);
        //}
        // GET: QLDCapi/categories/5
        [Route("QLDCapi/categories/{id:int:min(1)}")]
        [HttpGet]
        public IHttpActionResult GetCategory(int id)
        {
            var Category = _categoryRepository.GetById(id);
            if (Category == null)
            {
                return ApiNotFound();
            }
            return ApiOk(Category);
        }

        // PUT: QLDCapi/categories/5
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
            _categoryRepository.Update(change);
            return ApiNoContent();
        }

        // POST: QLDCapi/categories
        // [Route("QLDCapi/categories")]
        [ActionName("Index")]
        [HttpPost]
        public IHttpActionResult PostCategory(Category entity)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequest(null, ModelState);
            }
            var Category = _categoryRepository.Add(entity);
            return ApiCreated(Category);
        }

        // DELETE: QLDCapi/categories/5
        [Route("QLDCapi/categories/{id:int:min(1)}")]
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            var Category = _categoryRepository.Delete(id);
            return ApiOk();
        }

        // GET: QLDCapi/categories/count
        [Route("QLDCapi/categories/count")]
        [HttpGet]
        public IHttpActionResult GetCountCategory()
        {
            var count = _categoryRepository.Count();
            if (count == 0)
            {
                return ApiNotFound();
            }
            return ApiOk(count);
        }
    }
}
