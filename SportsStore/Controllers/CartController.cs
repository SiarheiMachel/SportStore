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
        
        public RedirectToRouteResult AddToCart(Cart cart, int id, string returnUrl)
        {
            var item = productRepository.GetAllProducts().FirstOrDefault(t => t.Id == id);

            if (item != null)
            {
                cart.Add(item, 1);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int id, string returnUrl)
        {
            var item = productRepository.GetAllProducts().FirstOrDefault(t => t.Id == id);

            if (item != null)
            {
                cart.Remove(item);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        public ActionResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
                {
                    Cart = cart,
                    ReturnURL = returnUrl
                });
        }

        public ActionResult Summary(Cart cart)
        {
            return View(cart);
        }

        public ActionResult Checkout()
        {
            return View(new ShippingDetailsModel());
        }
    }
}
