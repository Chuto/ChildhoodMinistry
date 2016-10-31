using System.Linq;
using ChildhoodMinistry.Contracts;
using ChildhoodMinistry.Data.Model;

namespace ChildhoodMinistry.BL
{
    public abstract class CrudService<T> : ICrudService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        protected CrudService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual IQueryable<T> GetItems()
        {
            return _repository.GetItems();
        }

        public virtual T GetItemById(int id)
        {
            return _repository.GetItemById(id);
        }

        public virtual void InsertItem(T item)
        {
            _repository.InsertItem(item);
            _repository.SaveChanges();
        }

        public virtual void UpdateItem(T item)
        {
            _repository.UpdateItem(item);
            _repository.SaveChanges();
        }

        public virtual void DeleteItem(int id)
        {
            _repository.DeleteItem(id);
            _repository.SaveChanges();
        }
    }
}
