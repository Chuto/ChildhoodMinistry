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
using ChildhoodMinistry.Data.Models;
using ChildhoodMinistry.DAL.Repository;

namespace ChildhoodMinistry.Dependency
{
    public class ChildhoodResolver : IDependencyResolver
    {
        private IUnityContainer container;


        public ChildhoodResolver()
        {
            this.container = new UnityContainer();

            container.RegisterType<IChildhoodService, ChildhoodService>(new TransientLifetimeManager()); 
            container.RegisterType<IChildService, ChildService>(new TransientLifetimeManager());
            
            container.RegisterType<IRepository<Child>, GenericRepository<Child>>(new TransientLifetimeManager());
            container.RegisterType<IRepository<Childhood>, GenericRepository<Childhood>>(new TransientLifetimeManager());
        }

        public object GetService(Type serviceType)
        {
            //if (container.IsRegistered(serviceType))
            //     container.Resolve(serviceType);
            //else
            //    return null;
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
