using System.Data.Entity;
using System.Linq;

namespace SportsStore.DataAccess.Repositories
{
    public class ProductRepository : EntityFrameworkRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {

        }

        public IQueryable<Product> GetAllProducts()
        {
            return DbSet;
        }
    }
}
