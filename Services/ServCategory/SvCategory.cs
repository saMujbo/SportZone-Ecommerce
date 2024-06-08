using Entidades;
using Microsoft.EntityFrameworkCore;
using Services.MyDbContext;

namespace Services.ServCategory
{
    public class SvCategory : ISvCategory
    {
        private MyContext _myDbContext = default!;
        public SvCategory()
        {
            _myDbContext = new MyContext();
        }

        #region Writes
        public Category AddCategory(Category category)
        {
            _myDbContext.Categories.Add(category);
            _myDbContext.SaveChanges();

            return category;
        }

        public void DeleteCategory(int id)
        {
            Category deleteCategory = _myDbContext.Categories.Find(id);
            if (deleteCategory != null)
            {
                //_myDbContext.Customers.Remove(deleteCustomer);
                deleteCategory.ChangeIsActive();
                _myDbContext.Categories.Update(deleteCategory);
                _myDbContext.SaveChanges();
            }
        }
        #endregion

        #region Reads
        public List<Category> GetAllCategories()
        {
            return _myDbContext.Categories.Include(x => x.Shoes).Where(Category => Category.IsActive).ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _myDbContext.Categories.Where(Categoria => Categoria.IsActive).Include(x => x.Shoes).SingleOrDefault(x => x.Id == id);
        }

        public Category UpdateCategory(int id, Category category)
        {
            Category categoryUpdate = _myDbContext.Categories.Find(id);
            if(categoryUpdate == null)
            {
                return null;
            }
           else
            {
                categoryUpdate.Name = category.Name;

                _myDbContext.Update(categoryUpdate);
                _myDbContext.SaveChanges();

                return categoryUpdate;
            }
        }

        #endregion
    }
}
