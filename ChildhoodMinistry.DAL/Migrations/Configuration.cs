using System.Data.Entity.Migrations;
using ChildhoodMinistry.Data.Model;

namespace ChildhoodMinistry.DAL.Migrations
{
    internal sealed class Configuration :
        DbMigrationsConfiguration<ChildhoodMinistryContext>
    {
        protected override void Seed(ChildhoodMinistryContext context)
        {
            base.Seed(context);

            context.Children.Add(new Child { Name = "����", Surname = "������", Patronymic = "�������������", Age = 8, ChildhoodId = 1 });
            context.Children.Add(new Child { Name = "���������", Surname = "������", Patronymic = "������������", Age = 7, ChildhoodId = 1 });
            context.Children.Add(new Child { Name = "���������", Surname = "��������", Patronymic = "����������", Age = 7, ChildhoodId = 2 });
            context.Children.Add(new Child { Name = "���", Surname = "���������", Patronymic = "����������", Age = 8, ChildhoodId = 3 });

            context.Childhoods.Add(new Childhood { Number = 1, Adress = "���������� 9" });
            context.Childhoods.Add(new Childhood { Number = 2, Adress = "���������� 101" });
            context.Childhoods.Add(new Childhood { Number = 3, Adress = "���������� 12" });

            context.SaveChanges();
        }
    }
}
