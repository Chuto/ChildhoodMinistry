using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using ChildhoodMinistry.Data.Models;

namespace ChildhoodMinistry.DAL.Migrations
{
    internal sealed class Configuration :
        DbMigrationsConfiguration<ChildhoodMinistryContext>
    {
        protected override void Seed(ChildhoodMinistryContext context)
        {
            base.Seed(context);

            var children_data = context.Set<Child>();
            var childhoods_data = context.Set<Childhood>();

            children_data.Add(new Child { Name = "����", Surname = "������", Patronymic = "�������������", Age = 8, ChildhoodId = 1 });
            children_data.Add(new Child { Name = "���������", Surname = "������", Patronymic = "������������", Age = 7, ChildhoodId = 1 });
            children_data.Add(new Child { Name = "���������", Surname = "��������", Patronymic = "����������", Age = 7, ChildhoodId = 2 });
            children_data.Add(new Child { Name = "���", Surname = "���������", Patronymic = "����������", Age = 8, ChildhoodId = 3 });

            childhoods_data.Add(new Childhood { Number = 1, Adress = "���������� 9" });
            childhoods_data.Add(new Childhood { Number = 2, Adress = "���������� 101" });
            childhoods_data.Add(new Childhood { Number = 3, Adress = "���������� 12" });

            context.SaveChanges();
        }
    }
}
