using Entidades;

namespace Services.ServPurchaseDetail
{
    public interface ISvPurchaseDatail
    {
        //READS
        public List<PurchaseDetail> GetAllPurchases();
        public PurchaseDetail GetPurchaseById(int id);

        //WRITES
        public PurchaseDetail AddPurchase(PurchaseDetail purchase);
        public PurchaseDetail UpdatePurchase(int id, PurchaseDetail purchase);
        public void DeletePurchase(int id);
    }
}