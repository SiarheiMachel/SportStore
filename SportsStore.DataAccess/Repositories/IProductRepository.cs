using System.Linq;

namespace SportsStore.DataAccess.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAllProducts();
    }
}
