﻿namespace WebApplication2.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public int Price { get; set; }

        public string ShopCartId { get; set; }
    }
}
