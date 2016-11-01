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
            childhoodList.Add(new Childhood { Number = 1, Adress = "Притыцкого 9" });
            childhoodList.Add(new Childhood { Number = 2, Adress = "Филимонова 101" });
            childhoodList.Add(new Childhood { Number = 3, Adress = "Лещинского 12" });

            foreach (var item in childhoodList)
                context.Childhoods.Add(item);

            context.Children.Add(new Child { Name = "Петр", Surname = "Зайцев", Patronymic = "Александрович", Age = 8, Childhood = childhoodList.Single(s => s.Number == 1) });
            context.Children.Add(new Child { Name = "Екатерина", Surname = "Бублик", Patronymic = "Владимировна", Age = 7, Childhood = childhoodList.Single(s => s.Number == 1) });
            context.Children.Add(new Child { Name = "Александр", Surname = "Петросян", Patronymic = "Викторович", Age = 7, Childhood = childhoodList.Single(s => s.Number == 2) });
            context.Children.Add(new Child { Name = "Юля", Surname = "Крутковец", Patronymic = "Эдуардовна", Age = 8, Childhood = childhoodList.Single(s => s.Number == 3) });

            context.SaveChanges();
        }
    }
}