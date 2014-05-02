using System.Data.Entity;
using Ninject;
using SportsStore.DataAccess.Repositories;

namespace SportsStore.DataAccess
{
    public class NInjectCotainer : IContainer
    {
        private readonly IKernel _kernel;

        public NInjectCotainer(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void Init()
        {
            _kernel.Bind<DbContext>().To<SportStore>().InSingletonScope();
            _kernel.Bind<IProductRepository>().To(typeof (ProductRepository));
        }
    }
}
