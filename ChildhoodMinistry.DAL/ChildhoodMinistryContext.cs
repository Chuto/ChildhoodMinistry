namespace ChildhoodMinistry.DAL
{
    using Data.Model;
    using System.Data.Entity;

    public class ChildhoodMinistryContext : DbContext
    {
        public ChildhoodMinistryContext()
            : base("name=ContextDB")
        {
        }

        public DbSet<Child> Children { get; set; }
        public DbSet<Childhood> Childhoods { get; set; } 
    }
}