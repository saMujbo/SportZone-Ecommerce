using Microsoft.AspNetCore.Mvc;
using Entidades;
using Services.Shoe;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoeController : ControllerBase
    {
        private ISvShoe _svShoe;
        public ShoeController(ISvShoe svShoe)
        {
            _svShoe = svShoe;
        }

        // GET: api/<ShoeController>
        [HttpGet]
        public IEnumerable<Shoe> Get()
        {
            return _svShoe.GetAllShoes();
        }

        // GET api/<ShoeController>/5
        [HttpGet("{id}")]
        public Shoe Get(int id)
        {
            return _svShoe.GetShoeById(id);
        }

        // POST api/<ShoeController>
        [HttpPost]
        public void Post([FromBody] Shoe shoe)
        {
            _svShoe.AddShoe(shoe);
        }

        // PUT api/<ShoeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Shoe shoe)
        {
            _svShoe.UpdateShoe(id, shoe);
        }

        // DELETE api/<ShoeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _svShoe.DeleteShoe(id);
        }
    }
}
