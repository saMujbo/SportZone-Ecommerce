using System.Text.Json.Serialization;

namespace Entidades
{
    public class Customer
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; private set; }

        [JsonIgnore]
        public List<Invoice>? Invoices { get; set; }
        [JsonIgnore]
        public List<PurchaseDetail>? PurchaseDetails { get; set; }

        public Customer() { IsActive = true; }

        public void ChangeIsActive() { IsActive = false; }
    }
}
