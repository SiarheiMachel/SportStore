using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using SportsStore.DataAccess;
using SportsStore.Web.Services;

namespace SportsStore.Web.Infrastructure
{
    public class ControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel ninjectKernel;
        private readonly IContainer container;

        public ControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            container = new NInjectCotainer(ninjectKernel);
            Initialize();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController) ninjectKernel.Get(controllerType);
        }

        private void Initialize()
        {
            container.Init();
            ninjectKernel.Bind<IOrderService>().To<OrderService>();
        }
    }
}