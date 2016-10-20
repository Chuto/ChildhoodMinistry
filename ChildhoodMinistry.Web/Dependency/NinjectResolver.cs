using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using Ninject;
using ChildhoodMinistry.Contracts;
using ChildhoodMinistry.Data.Models;
using ChildhoodMinistry.DAL.Repository;
using ChildhoodMinistry.DAL;
using ChildhoodMinistry.BL;

namespace ChildhoodMinistry.Web
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IRepository<Child>>().To<GenericRepository<Child>>().InSingletonScope();
            kernel.Bind<IRepository<Childhood>>().To<GenericRepository<Childhood>>().InSingletonScope();
            kernel.Bind<IChildService>().To<ChildService>().InTransientScope();
            kernel.Bind<IChildhoodService>().To<ChildhoodService>().InTransientScope();
            kernel.Bind<DbContext>().To<ChildhoodMinistryContext>().InSingletonScope();
        }
    }
}
