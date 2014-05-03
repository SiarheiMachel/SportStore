using System.Linq;
using System.Web.Mvc;
using SportsStore.DataAccess.Repositories;
using SportsStore.Web.Models;

namespace SportsStore.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository productRepository;

        public CartController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Cart Cart
        {
            get
            {
                var cartInSession = (Cart)Session["Cart"];

                if (cartInSession != null) return cartInSession;
                var cart = new Cart();
                Session["Cart"] = cart;
                return cart;
            }
        }

        public RedirectToRouteResult AddToCart(int id, string returnUrl)
        {
            var item = productRepository.GetAllProducts().FirstOrDefault(t => t.Id == id);

            if (item != null)
            {
                Cart.Add(item, 1);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(int id, string returnUrl)
        {
            var item = productRepository.GetAllProducts().FirstOrDefault(t => t.Id == id);

            if (item != null)
            {
                Cart.Remove(item);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        public ActionResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
                {
                    Cart = Cart,
                    ReturnURL = returnUrl
                });
        }
    }
}
