using WebApplication2.Data.Interfaces;
using WebApplication2.Data.Models;

namespace WebApplication2.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { Name = "Электромобили", Description = "Современный вид транспорта" },
                    new Category { Name = "Классические автомобили", Description = "Машины с двигателем внутреннего згорания" }
                };
            }
        }
    }
}
