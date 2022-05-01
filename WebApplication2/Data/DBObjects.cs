using WebApplication2.Data.Models;

namespace WebApplication2.Data
{
    public class DBObjects
    {
        private static Dictionary<string, Category> _category;

        public static void Initialize(AppDBContent content)
        {   
            if(!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if(!content.Car.Any())
            {
                content.AddRange(
                    new List<Car>
                    {
                        new Car { Name = "Tesla Model S",
                            ShortDescription = "Бесшумный и безопасный",
                            LongDescription = "",
                            ImageURL = "/img/tesla model s.jpg",
                            Price = 45000,
                            IsFavourite = true,
                            Available = true,
                            Category = Categories["Электромобили"]
                        },

                        new Car { Name = "BMW 3 f30",
                            ShortDescription = "Дерзкий и стильный",
                            LongDescription = "Удобный автомобиль для городской жизни",
                            ImageURL = "/img/bmw.jpg",
                            Price = 45000,
                            IsFavourite = false,
                            Available = true,
                            Category = Categories["Классические автомобили"]
                        }
                    } 
                    );
            }

            content.SaveChanges();
        }

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_category == null)
                {
                    var list = new List<Category>
                    {
                        new Category { Name = "Электромобили", Description = "Современный вид транспорта" },
                        new Category { Name = "Классические автомобили", Description = "Машины с двигателем внутреннего згорания" }
                    };

                    _category = new Dictionary<string, Category>();
                    foreach (Category c in list)
                    {
                        _category.Add(c.Name, c);
                    };
                }

                return _category;
            }
        }
    }
}
