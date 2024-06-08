using Entidades;
using Microsoft.AspNetCore.Mvc;
using Services.ServPurchaseDetail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseDetailController : ControllerBase
    {
        private ISvPurchaseDatail _svPurchaseDetail;
        public PurchaseDetailController(ISvPurchaseDatail svPurchaseDetail)
        {
            _svPurchaseDetail = svPurchaseDetail;
        }

        // GET: api/<PurchaseDetailController>
        [HttpGet]
        public IEnumerable<PurchaseDetail> Get()
        {
            return _svPurchaseDetail.GetAllPurchases();
        }

        // GET api/<PurchaseDetailController>/5
        [HttpGet("{id}")]
        public PurchaseDetail Get(int id)
        {
            return _svPurchaseDetail.GetPurchaseById(id);
        }

        // POST api/<PurchaseDetailController>
        [HttpPost]
        public void Post([FromBody] PurchaseDetail purchase)
        {
            _svPurchaseDetail.AddPurchase(purchase);
        }

        // PUT api/<PurchaseDetailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PurchaseDetail purchase)
        {
            _svPurchaseDetail.UpdatePurchase(id, purchase);
        }

        // DELETE api/<PurchaseDetailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _svPurchaseDetail.DeletePurchase(id);
        }
    }
}
