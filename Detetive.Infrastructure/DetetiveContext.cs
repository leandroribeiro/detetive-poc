using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Detetive.Domain.Entities;

namespace Detetive.Infrastructure
{
    public class DetetiveContext : DbContext
    {
        public DetetiveContext() : base("name=DetetiveContext")
        {
            
        }

        public DbSet<Arma> Armas { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Suspeito> Suspeitos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ArmaMap());
            modelBuilder.Configurations.Add(new LocalMap());
            modelBuilder.Configurations.Add(new SuspeitoMap());

        }

    }
}
