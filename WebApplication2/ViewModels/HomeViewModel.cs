using WebApplication2.Data.Models;

namespace WebApplication2.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> GetFavouriteCars { get; set; }
    }
}
