using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SportsStore.DataAccess.Repositories;
using SportsStore.Web.Models;

namespace SportsStore.Web.Controllers
{
    public class NavigationController : Controller
    {
        private readonly IProductRepository _productRepository;

        public NavigationController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public PartialViewResult Menu(string category = null)
        {
            IEnumerable<string> categories = _productRepository.GetAllProducts()
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(new NavigationModel
            {
                Categories = categories,
                CurrentCategory = category
            });
        }
    }
}
