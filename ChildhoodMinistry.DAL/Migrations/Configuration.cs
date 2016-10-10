using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using ChildhoodMinistry.DAL.Models;

namespace ChildhoodMinistry.DAL.Migrations
{
    internal sealed class Configuration :
        DbMigrationsConfiguration<ContextDB>
    {
        protected override void Seed(ContextDB context)
        {
            base.Seed(context);

            context.children_data.Add(new Child { Name = "����", Surname = "������", Patronymic = "�������������", Age = 8, ChildhoodId = 1 });
            context.children_data.Add(new Child { Name = "���������", Surname = "������", Patronymic = "������������", Age = 7, ChildhoodId = 1 });
            context.children_data.Add(new Child { Name = "���������", Surname = "��������", Patronymic = "����������", Age = 7, ChildhoodId = 2 });
            context.children_data.Add(new Child { Name = "���", Surname = "���������", Patronymic = "����������", Age = 8, ChildhoodId = 3 });

            context.childhoods_data.Add(new Childhood { Number = 1, Adress = "���������� 9" });
            context.childhoods_data.Add(new Childhood { Number = 2, Adress = "���������� 101" });
            context.childhoods_data.Add(new Childhood { Number = 3, Adress = "���������� 12" });

            context.SaveChanges();

        }
    }
}