using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data.Models;
using WebApplication2.Data.Interfaces;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRepository;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRepository, ShopCart shopCart)
        {
            _carRepository = carRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetCartItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRepository.GetAllCars.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
