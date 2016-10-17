using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Web.Mvc;
using ChildhoodMinistry.DAL.Intarface;
using ChildhoodMinistry.DAL.Models;
using ChildhoodMinistry.DAL.Repository;
using ChildhoodMinistry.BL;

namespace ChildhoodMinistry.Dependency
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
        }
    }
}
