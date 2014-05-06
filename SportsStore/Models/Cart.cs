using System.Collections.Generic;
using System.Linq;
using SportsStore.DataAccess;

namespace SportsStore.Web.Models
{
    public class Cart
    {
        private readonly List<CartItem> cartItems;

        public Cart()
        {
            cartItems = new List<CartItem>();
        }

        public void Add(Product item, int quantity)
        {
            var itemInCart = cartItems.FirstOrDefault(t => t.Item.Id == item.Id);

            if (itemInCart == null)
            {
                cartItems.Add(new CartItem
                {
                    Item = item,
                    Quantity = quantity
                });
            }
            else
            {
                itemInCart.Quantity += quantity;
            }
        }

        public void Remove(Product item)
        {
            cartItems.RemoveAll(t => t.Item.Id == item.Id);
        }

        public void Clear()
        {
            cartItems.Clear();
        }

        public decimal TotalValue
        {
            get { return cartItems.Sum(t => t.Item.Price*t.Quantity); }
        }

        public IEnumerable<CartItem> CartItems
        {
            get { return cartItems; }
        } 
    }

    public class CartItem
    {
        public Product Item { get; set; }
        public int Quantity { get; set; }
    }
}