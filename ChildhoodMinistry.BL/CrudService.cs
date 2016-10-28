using System.Collections.Generic;
using System.Linq;
using ChildhoodMinistry.Contracts;
using ChildhoodMinistry.Data.Model;

namespace ChildhoodMinistry.BL
{
    public class CrudService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        protected CrudService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public IQueryable<T> GetItems()
        {
            return _repository.GetItems();
        }

        public T GetItemById(int id)
        {
            return _repository.GetItemById(id);
        }

        public void InsertItem(T item)
        {
            _repository.InsertItem(item);
            _repository.SaveChanges();
        }

        public void UpdateItem(T item)
        {
            _repository.UpdateItem(item);
            _repository.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            _repository.DeleteItem(id);
            _repository.SaveChanges();
        }
    }
}
