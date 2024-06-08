using Entidades;
using Microsoft.EntityFrameworkCore;
using Services.Customer;
using Services.MyDbContext;
using Services.NewFolder;
using Services.ServPurchaseDetail;


namespace Services.Invoice
{
    public class SvInvoice : ISvInvoice
    {
        private MyContext _myDbContext = default!;
        private SvCustomer _svCustomer = default!;
        private SvPurchaseDatail _svPurchaseDetail = default!;
        public SvInvoice()
        {
            _myDbContext = new MyContext();
            _svCustomer = new SvCustomer();
            _svPurchaseDetail = new SvPurchaseDatail();
        }

        #region Writes
        public Entidades.Invoice AddInvoice(Entidades.Invoice newInvoice)
        {
            Entidades.Customer custumer = _svCustomer.GetCostumerById(newInvoice.CostumerId);
            if (custumer == null)
            {
                return newInvoice = null;
            }
            else
            {
                List<PurchaseDetail> purchaseDetails = _svPurchaseDetail.GetAllPurchasesByCustumerId(newInvoice.CostumerId);
                if (!purchaseDetails.Any())
                {
                    return newInvoice = null;
                }
                else
                {
                    newInvoice.Sets(purchaseDetails);
                    _myDbContext.Invoices.Add(newInvoice);
                    _myDbContext.SaveChanges();
                    InvoiceMail(newInvoice, purchaseDetails);
                    _svPurchaseDetail.DeletePurchasesByCustumerId(purchaseDetails);
                    return newInvoice;
                }
            }
        }
        #endregion

        #region Reads
        public List<Entidades.Invoice> GetAllInvoices()
        {
            return _myDbContext.Invoices.Include(x => x.Customer).ToList();
        }

        public Entidades.Invoice GetInvoiceById(int invoiceId)
        {
            return _myDbContext.Invoices.Include(x => x.Customer).SingleOrDefault(x => x.Id == invoiceId);
        }
        #endregion

        #region Utilities
        void InvoiceMail(Entidades.Invoice invoice, List<PurchaseDetail> purchaseDetails_Customer)
        {
            // Obtener información del cliente
            Entidades.Customer customer = _svCustomer.GetCostumerById(invoice.CostumerId);

            // Enviar correo electrónico
            Mail mail = new Mail();
            string body = mail.GenerateHtml(purchaseDetails_Customer, invoice, customer);
            mail.sendMail(customer.Email, "Factura SportZone", body);
        }
        #endregion
    }
}





























//objLogic.sendMail("samuelbarrantes1@gmail.com", "Este correo fue enviado via C-sharp", body);