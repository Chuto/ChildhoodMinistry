using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using ChildhoodMinistry.Data.Model;

namespace ChildhoodMinistry.DAL.Migrations
{
    internal sealed class Configuration :
        DbMigrationsConfiguration<ChildhoodMinistryContext>
    {
        protected override void Seed(ChildhoodMinistryContext context)
        {
            base.Seed(context);

            IList<Childhood> childhoodList = new List<Childhood>();
            childhoodList.Add(new Childhood { Number = 1, Adress = "���������� 9" });
            childhoodList.Add(new Childhood { Number = 2, Adress = "���������� 101" });
            childhoodList.Add(new Childhood { Number = 3, Adress = "���������� 12" });

            foreach (var item in childhoodList)
                context.Childhoods.Add(item);

            context.Children.Add(new Child { Name = "����", Surname = "������", Patronymic = "�������������", Age = 8, Childhood = childhoodList.Single(s => s.Number == 1) });
            context.Children.Add(new Child { Name = "���������", Surname = "������", Patronymic = "������������", Age = 7, Childhood = childhoodList.Single(s => s.Number == 1) });
            context.Children.Add(new Child { Name = "���������", Surname = "��������", Patronymic = "����������", Age = 7, Childhood = childhoodList.Single(s => s.Number == 2) });
            context.Children.Add(new Child { Name = "���", Surname = "���������", Patronymic = "����������", Age = 8, Childhood = childhoodList.Single(s => s.Number == 3) });

            context.SaveChanges();
        }
    }
}