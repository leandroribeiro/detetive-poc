namespace Detetive.Infrastructure.Migrations
{
    using Detetive.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DetetiveContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DetetiveContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Armas.AddOrUpdate(x => x.ID,
                new Arma("Fusioncutter"),
                new Arma("Wrist Rockets"),
                new Arma("Flamethower "),
                new Arma("Missile Launchers"),
                new Arma("Ryyk Blades"),
                new Arma("Flechette Launcher"),
                new Arma("Force Pike"),
                new Arma("Bowcaster "),
                new Arma("Blaster"),
                new Arma("Lightsaber")
            );

            context.Locais.AddOrUpdate(x => x.ID,
                new Local("Ahch-To"),
                new Local("Alderaan"),
                new Local("Bespin"),
                new Local("Cato Neimoidia"),
                new Local("Christophsis"),
                new Local($"Coruscant"),
                new Local("Crait"),
                new Local("D'Qar"),
                new Local("Dagobah"),
                new Local("Eadu"),
                new Local("Endor"),
                new Local("Felucia"),
                new Local("Geonosis"),
                new Local("Hosnian Prime")
            );

            context.Suspeitos.AddOrUpdate(x => x.ID,
                new Suspeito("Darth Vader"),
                new Suspeito("Darth Maul"),
                new Suspeito("Darth Sidious"),
                new Suspeito("Strorm Trooper"),
                new Suspeito("Boba Fett"),
                new Suspeito("GRAND MOFF TARKIN"),
                new Suspeito("JABBA THE HUTT"),
                new Suspeito("COUNT DOOKU"),
                new Suspeito("GENERAL GRIEVOUS"),
                new Suspeito("ASAJJ VENTRESS"),
                new Suspeito("CAD BANE")
            );

        }
    }
}
