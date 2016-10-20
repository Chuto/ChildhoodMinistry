using ChildhoodMinistry.DAL.Intarface;
using ChildhoodMinistry.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ChildhoodMinistry.DAL.Repository
{
    public class GenericRepository<T>: IDisposable, IRepository<T> where T : BaseEntity
    {
        private readonly ContextDB context;
        private IDbSet<T> entities;

        public GenericRepository(ContextDB context)
        {
            this.context = context;
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = context.Set<T>();
                }
                return entities;
            }
        }

        public IQueryable<T> GetItems()
        {
            return (from items in this.Entities
                    select items);
        }

        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public void InsertItem(T entity)
        {
            this.Entities.Add(entity);
        }

        public void UpdateItem(T entity, object id)
        {
            Entities.Remove(Entities.Find(id));
            Entities.Add(entity);
        }

        public void DeleteItem(T entity)
        {
            Entities.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }


        void IDisposable.Dispose()
        {
            if (context!=null)
                 context.Dispose();
        }
    }
}
