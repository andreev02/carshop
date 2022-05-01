using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data.Interfaces;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRepository;

        public HomeController(IAllCars carRepository)
        {
            _carRepository = carRepository;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                GetFavouriteCars = _carRepository.GetFavouriteCars
            };

            return View(homeCars);
        }
    }
}
