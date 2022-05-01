using WebApplication2.Data.Models;

namespace WebApplication2.Data.Interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
