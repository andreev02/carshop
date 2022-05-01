using WebApplication2.Data.Interfaces;
using WebApplication2.Data.Models;

namespace WebApplication2.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContent _appDBContent;

        public CategoryRepository(AppDBContent appDBConent)
        {
            _appDBContent = appDBConent;
        }

        public IEnumerable<Category> AllCategories => _appDBContent.Category;
    }
}
