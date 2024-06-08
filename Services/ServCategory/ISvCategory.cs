using Entidades;
namespace Services.ServCategory
{
    public interface ISvCategory
    {
        //reads
        public List<Category> GetAllCategories();

        public Category GetCategoryById(int id);

        //writes
        public Category AddCategory(Category category);

        public Category UpdateCategory(int id, Category category);

        public void DeleteCategory(int id);
    }
}
