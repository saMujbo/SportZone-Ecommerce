using Entidades;

namespace Services.Invoice
{
    public interface ISvInvoice
    {
        public Entidades.Invoice AddInvoice(Entidades.Invoice newInvoice);
        public Entidades.Invoice GetInvoiceById(int invoiceId);
        public List<Entidades.Invoice> GetAllInvoices();
    }
}
