using System.Text.Json.Serialization;

namespace Entidades
{
    public class Category
    {
        [JsonIgnore]
        public int Id { set; get; }
        public string Name { get; set; }
        public bool IsActive { get; private set; }
        [JsonIgnore]
        public List<Shoe>? Shoes { get; set; }
        public Category() { IsActive = true; }

        public void ChangeIsActive() { IsActive = false; }
    }
}
