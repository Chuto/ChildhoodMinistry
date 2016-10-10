namespace ChildhoodMinistry.DAL
{
    using Intarface;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ContextDB : DbContext
    {

        public ContextDB()
            : base("name=ContextDB")
        {
        }

        public DbSet<Child> children_data { get; set; }
        public DbSet<Childhood> childhoods_data { get; set; }

        public void save()
        {
            this.SaveChanges();
        }
    }

}