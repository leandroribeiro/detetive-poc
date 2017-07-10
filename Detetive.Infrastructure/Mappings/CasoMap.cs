using Detetive.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Detetive.Infrastructure
{
    internal class CasoMap : EntityTypeConfiguration<Caso>
    {
        public CasoMap()
        {
            this.ToTable("Casos");

            this.HasKey<int>(a => a.ID);

        }
    }
}