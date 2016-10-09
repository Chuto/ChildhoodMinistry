namespace ChildhoodMinistry.DAL
{
    using Intarface;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ContextDB : DbContext//, IContextDB
    {

        public ContextDB()
            : base("name=ContextDB")
        {
        }
        //public DbSet<Child> children_data { get; set; }
        //public DbSet<Childhood> childhoods_data { get; set; }

        public DbSet<Child> children_data { get; set; }
        public DbSet<Childhood> childhoods_data { get; set; }

        public void save()
        {
            this.SaveChanges();
        }

        //public IDbSet<TEntity> SetChildren<TEntity>() where TEntity : Child
        //{
        //    return base.Set<TEntity>();
        //}

        //public IDbSet<TEntity> SetChildhoods<TEntity>() where TEntity : Childhood
        //{
        //    return base.Set<TEntity>();
        //}
    }

}