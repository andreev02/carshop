using WebApplication2.Data.Interfaces;
using WebApplication2.Data.Models;

namespace WebApplication2.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();

        public IEnumerable<Car> GetAllCars {
            get {
                return new List<Car>
                {
                    new Car { Name = "Tesla Model S", 
                        ShortDescription = "Бесшумный и безопасный", 
                        LongDescription = "", 
                        ImageURL = "/img/tesla model s.jpg",
                        Price = 45000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.First()
                    },

                    new Car { Name = "BMW 3 f30",
                        ShortDescription = "Дерзкий и стильный",
                        LongDescription = "Удобный автомобиль для городской жизни",
                        ImageURL = "/img/bmw.jpg",
                        Price = 45000,
                        IsFavourite = false,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Car> GetFavouriteCars { get; set; }

        public Car GetCarByID(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
