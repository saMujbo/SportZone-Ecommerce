using System.Text.Json.Serialization;

namespace Entidades
{
    public class Shoe
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Size { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; private set; }
        //
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
        public Shoe() { IsActive = true; }
        public void ChangeIsActive() { IsActive = false; }

        public bool SubtractStock(int quantity)
        {
            if (quantity > this.Stock)
            {
                return false;
            }
            else
            {
                this.Stock = this.Stock - quantity;
                return true;
            }
        }

        public void plusStock(int quantity) { this.Stock += quantity; }
    }
}
