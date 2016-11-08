using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using ChildhoodMinistry.Contracts;
using ChildhoodMinistry.DAL;
using ChildhoodMinistry.Web.Interface;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Web.Common;


namespace ChildhoodMinistry.Web.Dependency
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel Kernel { get; }
        public NinjectControllerFactory(IKernel kernel)
        {
            Kernel = kernel;
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IController controller = null;

            if (controllerType != null)
                controller = (IController)Kernel.Get(controllerType);

            return controller;
        }

        private void AddBindings()
        {
            Kernel.Bind(convention => convention
                .FromAssembliesMatching("ChildhoodMinistry.*")
                .SelectAllClasses()
                .InheritedFrom(typeof(IRepository<>))
                .BindSingleInterface()
                .Configure(obj => obj.InTransientScope())
            );

            Kernel.Bind(convention => convention
                .FromAssembliesMatching("ChildhoodMinistry.*")
                .SelectAllClasses()
                .InheritedFrom(typeof(IModelBuilder<,>))
                .BindSingleInterface()
                .Configure(obj => obj.InTransientScope())
            );

            Kernel.Bind(convention => convention
                .FromAssembliesMatching("ChildhoodMinistry.*")
                .SelectAllClasses()
                .Where(t => t.Name.EndsWith("Service"))
                .BindDefaultInterface()
                .Configure(obj => obj.InTransientScope())
            );

            Kernel.Bind<DbContext>().To<ChildhoodMinistryContext>().InRequestScope();
        }
    }
}