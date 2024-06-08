using Entidades;

namespace Services.Shoe
{
    public interface ISvShoe
    {
        //READS
        public List<Entidades.Shoe> GetAllShoes();
        public Entidades.Shoe GetShoeById(int id);

        //WRITES
        public Entidades.Shoe AddShoe(Entidades.Shoe shoe);
        public Entidades.Shoe UpdateShoe(int id, Entidades.Shoe shoe);
        public void DeleteShoe(int id);
    }
}
