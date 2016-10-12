using ChildhoodMinistry.BL;
using ChildhoodMinistry.DAL.Intarface;
using ChildhoodMinistry.DAL;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ChildhoodMinistry.DAL.Models;

namespace ChildhoodMinistry.Dependency
{
    public class ChildhoodResolver : IDependencyResolver
    {
        private IUnityContainer container;


        public ChildhoodResolver()
        {
            this.container = new UnityContainer();

            container.RegisterType<IChildhoodService, ChildhoodService>(new TransientLifetimeManager());
            container.RegisterType<IRepository<Childhood>, ChildhoodRepository>(new TransientLifetimeManager());

            container.RegisterType<IChildService, ChildService>(new TransientLifetimeManager());
            container.RegisterType<IRepository<Child>, ChildRepository>(new TransientLifetimeManager());
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch
            {
                return new List<object>();
            }
        }

    }
}
