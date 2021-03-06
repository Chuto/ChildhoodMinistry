﻿using System.Collections.Generic;

namespace ChildhoodMinistry.Contracts
{
    public interface ICrudService<T>
    {
        IList<T> GetItems();
        T GetItemById(int id);
        void InsertItem(T item);
        void UpdateItem(T item);
        void DeleteItem(int id); 
    }
}
