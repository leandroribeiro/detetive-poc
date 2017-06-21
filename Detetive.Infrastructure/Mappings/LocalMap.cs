using Detetive.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Detetive.Infrastructure
{
    internal class LocalMap : EntityTypeConfiguration<Local>
    {
        public LocalMap()
        {
            this.ToTable("Locais");

            this.HasKey<int>(a => a.ID);

            this.Property(a => a.Nome)
                .IsRequired();
        }

        //http://www.entityframeworktutorial.net/code-first/move-configurations-to-seperate-class-in-code-first.aspx
        //http://netcoders.com.br/mapeamento-com-entity-framework-code-first-fluent-api-parte-2/
    }
}