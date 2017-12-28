using Detetive.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Detetive.Infrastructure
{
    internal class CasoMap : EntityTypeConfiguration<Caso>
    {
        public CasoMap()
        {
            this.ToTable("Casos");

            this.HasKey<int>(a => a.Id);

            HasRequired(x => x.Arma)
                .WithMany(x => x.Casos)
                .HasForeignKey(x => x.ArmaId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Local)
                .WithMany(x=>x.Casos)
                .HasForeignKey(x=>x.LocalId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Suspeito)
                .WithMany(x=>x.Casos)
                .HasForeignKey(x=>x.SuspeitoId)
                .WillCascadeOnDelete(false);

        }

        
    }
}