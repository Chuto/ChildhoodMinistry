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
    public class ChildMap : EntityTypeConfiguration<Child>
    {
        public ChildMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired();
            Property(t => t.Surname).IsRequired();
            Property(t => t.Patronymic).IsRequired();
            Property(t => t.Age).IsRequired();
            Property(t => t.ChildhoodId).IsRequired();
            ToTable("Children");
        }
    }
}
