using System.Collections.Generic;
using System.Linq;
using ChildhoodMinistry.Contracts;
using ChildhoodMinistry.Data.Model;

namespace ChildhoodMinistry.BL
{
    public class CrudService<T> : ICrudService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository; 

        public CrudService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public List<T> GetItems()
        {
            return _repository.GetItems().ToList();
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
            _repository.UpdateItem(item, item.Id);
            _repository.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            _repository.DeleteItem(id);
            _repository.SaveChanges();
        }
    }
}
