using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using Ninject;
using SportsStore.DataAccess;
using SportsStore.DataAccess.Repositories;

namespace SportsStore.Web.Infrastructure
{
    public class ControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;
        private readonly IContainer container;

        public ControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            container = new NInjectCotainer(_ninjectKernel);
            Initialize();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController) _ninjectKernel.Get(controllerType);
        }

        private void Initialize()
        {
            container.Init();
        }
    }
}