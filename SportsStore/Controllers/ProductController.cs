using System.Linq;
using System.Web.Mvc;
using SportsStore.DataAccess.Repositories;
using SportsStore.Web.Models;

namespace SportsStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public int PageSize = 2;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            var products = productRepository.GetAllProducts()
                .Where(t => category == null || t.Category == category)
                .OrderBy(t => t.Id)
                .Skip((page - 1)*PageSize)
                .Take(PageSize)
                .ToList();
            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = category == null 
                    ? productRepository.GetAllProducts().Count()
                    : productRepository.GetAllProducts().Count(t => t.Category == category)
            };

            return View(new ProductListModel
            {
                PagingInfo = pagingInfo,
                Products = products,
                CurrentCategory = category
            });
        }

    }
}
