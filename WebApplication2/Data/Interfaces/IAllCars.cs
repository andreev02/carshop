using WebApplication2.Data.Models;

namespace WebApplication2.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> GetAllCars { get; }
        IEnumerable<Car> GetFavouriteCars { get; }
        Car GetCarByID(int carId);
    }
}
