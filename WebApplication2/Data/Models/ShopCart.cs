using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent _appDBContent;

        public ShopCart(AppDBContent appDBConent)
        {
            _appDBContent = appDBConent;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Car car)
        {
            _appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Car = car,
                Price = car.Price
            });

            _appDBContent.SaveChanges();
        }

        public List<ShopCartItem> GetCartItems()
        {
            return _appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Car).ToList();
        }
    }
}
