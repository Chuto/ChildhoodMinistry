using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using ChildhoodMinistry.Contracts;
using ChildhoodMinistry.DAL;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Web.Common;

namespace ChildhoodMinistry.Web.Dependency
{
    public class NinjectResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind(convention => convention
                .FromAssembliesMatching("ChildhoodMinistry.*")
                .SelectAllClasses()
                .InheritedFrom(typeof(IRepository<>))
                .BindSingleInterface()
                .Configure(obj => obj.InTransientScope())
            );

            _kernel.Bind(convention => convention
                .FromAssembliesMatching("ChildhoodMinistry.*")
                .SelectAllClasses()
                .InheritedFrom(typeof(IModelBuilder<,>))
                .BindSingleInterface()
                .Configure(obj => obj.InTransientScope())
            );

            _kernel.Bind(convention => convention
                .FromAssembliesMatching("ChildhoodMinistry.*")
                .SelectAllClasses()
                .Where(t => t.Name.EndsWith("Service"))
                .BindDefaultInterface()
                .Configure(obj => obj.InTransientScope())
            );

            _kernel.Bind<DbContext>().To<ChildhoodMinistryContext>().InRequestScope();
        }
    }
}
