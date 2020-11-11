using ElevenNote.Data;
using ElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    [Authorize]
    public class CategoryController : ApiController
    {
        public IHttpActionResult Get()
        {
            CategoryService categoryService = new CategoryService();

            var categories = categoryService.GetCategories();

            return Ok(categories);
        }

        public IHttpActionResult Post(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CategoryService categoryService = new CategoryService();

            if (!categoryService.CreateCategory(category))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            CategoryService categoryService = new CategoryService();
            var category = categoryService.GetCategoryById(id);
            return Ok(category);
        }

        public IHttpActionResult Put(Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CategoryService categoryService = new CategoryService();

            if (!categoryService.UpdateCategory(category))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            CategoryService categoryService = new CategoryService();

            if (!categoryService.DeleteCategory(id))
                return InternalServerError();

            return Ok();
        }
    }
}
