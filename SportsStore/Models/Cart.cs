using System.Collections.Generic;
using System.Linq;
using SportsStore.DataAccess;

namespace SportsStore.Web.Models
{
    public class Cart
    {
        private readonly List<CartItem> _cartItems;

        public Cart()
        {
            _cartItems = new List<CartItem>();
        }

        public void Add(Product item, int quantity)
        {
            var itemInCart = _cartItems.FirstOrDefault(t => t.Item.Id == item.Id);

            if (itemInCart == null)
            {
                _cartItems.Add(new CartItem
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
            _cartItems.RemoveAll(t => t.Item.Id == item.Id);
        }

        public void Clear()
        {
            _cartItems.Clear();
        }

        public decimal TotalValue
        {
            get { return _cartItems.Sum(t => t.Item.Price*t.Quantity); }
        }

        public IEnumerable<CartItem> CartItems
        {
            get { return _cartItems; }
        } 
    }

    public class CartItem
    {
        public Product Item { get; set; }
        public int Quantity { get; set; }
    }
}