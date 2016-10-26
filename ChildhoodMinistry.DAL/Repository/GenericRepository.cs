using System.Data.Entity;
using System.Linq;
using ChildhoodMinistry.Contracts;
using ChildhoodMinistry.Data.Model;

namespace ChildhoodMinistry.DAL.Repository
{
    public class GenericRepository<T>: IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private IDbSet<T> _entities;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        private IDbSet<T> Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }
        }

        public IQueryable<T> GetItems()
        {
            return Entities;
        }

        public T GetItemById(int id)
        {
            return Entities.Find(id);
        }

        public void InsertItem(T entity)
        {
            Entities.Add(entity);
        }

        public void UpdateItem(T entity, object id)
        {
            Entities.Remove(Entities.Find(id));
            Entities.Add(entity);
        }

        public void DeleteItem(int id)
        {
            Entities.Remove(Entities.Find(id));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
