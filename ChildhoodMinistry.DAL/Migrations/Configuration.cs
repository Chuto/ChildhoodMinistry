using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using ChildhoodMinistry.DAL.Models;
using System.Data.Entity;

namespace ChildhoodMinistry.DAL.Migrations
{
    internal sealed class Configuration :
        DbMigrationsConfiguration<ContextDB>
    {
        protected override void Seed(ContextDB context)
        {
            base.Seed(context);

            var children_data = context.Set<Child>();
            var childhoods_data = context.Set<Childhood>();

            children_data.Add(new Child { guid = Guid.NewGuid().ToString(), Name = "Петр", Surname = "Зайцев", Patronymic = "Александрович", Age = 8, ChildhoodId = 1 });
            children_data.Add(new Child { guid = Guid.NewGuid().ToString(), Name = "Екатерина", Surname = "Бублик", Patronymic = "Владимировна", Age = 7, ChildhoodId = 1 });
            children_data.Add(new Child { guid = Guid.NewGuid().ToString(), Name = "Александр", Surname = "Петросян", Patronymic = "Викторович", Age = 7, ChildhoodId = 2 });
            children_data.Add(new Child { guid = Guid.NewGuid().ToString(), Name = "Юля", Surname = "Крутковец", Patronymic = "Эдуардовна", Age = 8, ChildhoodId = 3 });

            childhoods_data.Add(new Childhood { guid = Guid.NewGuid().ToString(), Number = 1, Adress = "Притыцкого 9" });
            childhoods_data.Add(new Childhood { guid = Guid.NewGuid().ToString(), Number = 2, Adress = "Филимонова 101" });
            childhoods_data.Add(new Childhood { guid = Guid.NewGuid().ToString(), Number = 3, Adress = "Лещинского 12" });

            context.SaveChanges();
        }
    }
}
