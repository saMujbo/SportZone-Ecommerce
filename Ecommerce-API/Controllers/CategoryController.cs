using Microsoft.AspNetCore.Mvc;
using Entidades;
using Services.ServCategory;
using Services.Customer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ISvCategory _svCategory;
        public CategoryController(ISvCategory svCategory)
        {
            _svCategory = svCategory;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _svCategory.GetAllCategories();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _svCategory.GetCategoryById(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            _svCategory.AddCategory(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category category)
        {
            _svCategory.UpdateCategory(id, new Category
            {
                Name = category.Name
            });
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _svCategory.DeleteCategory(id);
        }
    }
}
