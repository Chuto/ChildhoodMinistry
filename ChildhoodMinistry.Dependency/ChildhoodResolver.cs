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

            container.RegisterType<IChildhoodService, ChildhoodService>();
            container.RegisterType<IRepository<Childhood>, ChildhoodRepository>();

            container.RegisterType<IChildService, ChildService>();
            container.RegisterType<IRepository<Child>, ChildRepository>();
            
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch
            {
                // TODO: Вернуть нормальную ошибку
                return null; //this.resolver.GetService(serviceType);
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
                // TODO: Вернуть нормальную ошибку
                return new List<object>();//resolver.GetServices(serviceType);
            }
        }

    }
}
