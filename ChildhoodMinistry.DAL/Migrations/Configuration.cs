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

            context.Children.Add(new Child { Name = "Петр", Surname = "Зайцев", Patronymic = "Александрович", Age = 8, ChildhoodId = 1 });
            context.Children.Add(new Child { Name = "Екатерина", Surname = "Бублик", Patronymic = "Владимировна", Age = 7, ChildhoodId = 1 });
            context.Children.Add(new Child { Name = "Александр", Surname = "Петросян", Patronymic = "Викторович", Age = 7, ChildhoodId = 2 });
            context.Children.Add(new Child { Name = "Юля", Surname = "Крутковец", Patronymic = "Эдуардовна", Age = 8, ChildhoodId = 3 });

            context.Childhoods.Add(new Childhood { Number = 1, Adress = "Притыцкого 9" });
            context.Childhoods.Add(new Childhood { Number = 2, Adress = "Филимонова 101" });
            context.Childhoods.Add(new Childhood { Number = 3, Adress = "Лещинского 12" });

            context.SaveChanges();
        }
    }
}
