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
            context.SaveChanges();
        }
    }
}
