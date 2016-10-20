using ChildhoodMinistry.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildhoodMinistry.DAL.Mapping
{
    public class ChildhoodMap : EntityTypeConfiguration<Childhood>
    {
        public ChildhoodMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Adress).IsRequired();
            Property(t => t.Number).IsRequired();
            ToTable("Childhoods");
        }
    }
}
