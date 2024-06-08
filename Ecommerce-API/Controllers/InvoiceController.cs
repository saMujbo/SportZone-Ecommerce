using Entidades;
using Microsoft.AspNetCore.Mvc;
using Services.Invoice;
using Services.ServPurchaseDetail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private ISvInvoice _svInvoice;
        public InvoiceController(ISvInvoice svInvoice)
        {
            _svInvoice = svInvoice;
        }
        // GET: api/<InvoiceController>
        [HttpGet]
        public IEnumerable<Invoice> Get()
        {
            return _svInvoice.GetAllInvoices();
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public Invoice Get(int id)
        {
            return _svInvoice.GetInvoiceById(id);
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public void Post([FromBody] Invoice invoice)
        {
            _svInvoice.AddInvoice(invoice);
        }
    }
}
