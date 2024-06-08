using Microsoft.EntityFrameworkCore;
using Services.MyDbContext;
using Services.ServCategory;

namespace Services.Shoe
{
    public class SvShoe : ISvShoe
    {
        private MyContext _myDbContext = default!;
        private SvCategory _svCategory = default!;
        public SvShoe()
        {
            _myDbContext = new MyContext();
            _svCategory = new SvCategory();
        }

        #region Writes
        public Entidades.Shoe AddShoe(Entidades.Shoe shoe)
        {
            _myDbContext.Shoes.Add(shoe);
            _myDbContext.SaveChanges();

            return shoe;
        }

        public void DeleteShoe(int id)
        {
            Entidades.Shoe deleteShoe = _myDbContext.Shoes.Find(id);
            if (deleteShoe != null)
            {
                //_myDbContext.Customers.Remove(deleteCustomer);
                deleteShoe.ChangeIsActive();
                _myDbContext.Shoes.Update(deleteShoe);
                _myDbContext.SaveChanges();
            }
        }
        public Entidades.Shoe UpdateShoe(int id, Entidades.Shoe shoe)
        {
            Entidades.Shoe shoeUpdate = _myDbContext.Shoes.Find(id);
            if (shoeUpdate == null)
            {
                return null;
            }
            else
            {
                shoeUpdate.Size = shoe.Size;
                shoeUpdate.Name = shoe.Name;
                shoeUpdate.Price = shoe.Price;
                shoeUpdate.Stock = shoe.Stock;

                _myDbContext.Shoes.Update(shoeUpdate);
                _myDbContext.SaveChanges();

                return shoeUpdate;
            }
        }
        public void UpdateStock(int id, Entidades.Shoe shoe)
        {
            Entidades.Shoe shoeUpdate = _myDbContext.Shoes.Find(id);
            shoeUpdate.Stock = shoe.Stock;

            _myDbContext.Shoes.Update(shoeUpdate);
            _myDbContext.SaveChanges();
        }
        #endregion

        #region Reads
            public List<Entidades.Shoe> GetAllShoes()
            {
                var listValidCategories = _svCategory.GetAllCategories().Select(x=>x.Id);
                return _myDbContext.Shoes.Include(x => x.Category).Where(Shoe => Shoe.IsActive && listValidCategories.Contains(Shoe.CategoryId)).ToList();
            }

        public Entidades.Shoe GetShoeById(int id)
        {
            var listValidCategories = _svCategory.GetAllCategories().Select(x => x.Id);
            return _myDbContext.Shoes.Include(x => x.Category).Where(Shoe => Shoe.IsActive && listValidCategories.Contains(Shoe.CategoryId)).SingleOrDefault(x => x.Id == id);
        }
        #endregion
    }
}
