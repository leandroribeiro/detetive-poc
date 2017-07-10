using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Detetive.Domain.Entities;

namespace Detetive.Infrastructure
{
    public class DetetiveContext : DbContext
    {
        public DetetiveContext(string connectionString) : base(connectionString)
        {
            
        }

        public DbSet<Arma> Armas { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Suspeito> Suspeitos { get; set; }
        public DbSet<Caso> Casos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Ignore<Testemunha>();

            modelBuilder.Configurations.Add(new ArmaMap());
            modelBuilder.Configurations.Add(new LocalMap());
            modelBuilder.Configurations.Add(new SuspeitoMap());
            modelBuilder.Configurations.Add(new CasoMap());

        }

    }
}
