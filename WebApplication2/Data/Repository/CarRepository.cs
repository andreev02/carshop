using WebApplication2.Data.Interfaces;
using WebApplication2.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent _appDBContent;

        public CarRepository(AppDBContent appDBConent)
        {
            _appDBContent = appDBConent;
        }

        public IEnumerable<Car> GetAllCars => _appDBContent.Car.Include(c => c.Category);

        public IEnumerable<Car> GetFavouriteCars => _appDBContent.Car.Where(c => c.IsFavourite).Include(c => c.Category);

        public Car GetCarByID(int carId) => _appDBContent.Car.FirstOrDefault(c => c.Id == carId);
    }
}
