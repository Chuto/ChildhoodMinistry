﻿using ChildhoodMinistry.DAL.Intarface;
using ChildhoodMinistry.DAL.Models;
using ChildhoodMinistry.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System;

using ChildhoodMinistry.DAL.Repository;

namespace ChildhoodMinistry.BL
{
    public class ChildService : IChildService
    {
        private IRepository<Child> children;

        public ChildService(IRepository<Child> children)
        {
            this.children = children;
        }

        public List<ChildViewModel> GetItems()
        {
            var result = new List<ChildViewModel>();
            foreach (var obj in children.GetItems())
            {
                result.Add(new ChildViewModel() {
                    Ind = obj.Id,
                    Name = obj.Name,
                    Surname = obj.Surname,
                    Patronymic = obj.Patronymic,
                    Age = obj.Age,
                    ChildhoodNum = obj.ChildhoodId                    
                });
            }         
            return result;
        }

        public ChildViewModel GetItemById(int id)
        {
            var obj = (from item in children.GetItems()
                       where item.Id == id
                       select item).First();

            return new ChildViewModel()
            {
                Ind = obj.Id,
                Name = obj.Name,
                Surname = obj.Surname,
                Patronymic = obj.Patronymic,
                Age = obj.Age,
                ChildhoodNum = obj.ChildhoodId
            };
        }

        public List<ChildViewModel> GetChildByChildhoodId(int id)
        {
            var result = new List<ChildViewModel>();
            foreach (var obj in children.GetItems().Where(s => s.ChildhoodId == id))
            {
                result.Add(new ChildViewModel()
                {
                    Ind = obj.Id,
                    Name = obj.Name,
                    Surname = obj.Surname,
                    Patronymic = obj.Patronymic,
                    Age = obj.Age,
                    ChildhoodNum = obj.ChildhoodId
                });
            }
            return result;
        }

        public void InsertItem(ChildViewModel item)
        {
            children.InsertItem(new Child() {
                Id = item.Ind,
                guid = Guid.NewGuid().ToString(),
                Name = item.Name,
                Surname = item.Surname,
                Patronymic = item.Patronymic,
                Age = item.Age,
                ChildhoodId = item.ChildhoodNum
            });
        }

        public void UpdateItem(ChildViewModel item)
        {
            children.UpdateItem(new Child()
            {
                Id = item.Ind,
                Name = item.Name,
                Surname = item.Surname,
                Patronymic = item.Patronymic,
                Age = item.Age,
                ChildhoodId = item.ChildhoodNum
            }, item.Ind);
        }
        
        public void DeleteItem(int id)
        {
            var obj = (from item in children.GetItems()
                       where item.Id == id
                       select item).First();
            children.DeleteItem(obj);
        }
    }
}
