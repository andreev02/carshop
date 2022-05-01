using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data.Interfaces;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars IAllCars, ICarsCategory ICarsCategory)
        {
            _allCars = IAllCars;
            _allCategories = ICarsCategory;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Страница с автомобилями";

            CarsListViewModel _object = new CarsListViewModel();
            _object.AllCars = _allCars.GetAllCars;
            _object.CurrentCategory = "Все автомобили";
            return View(_object);
        }
    }
}