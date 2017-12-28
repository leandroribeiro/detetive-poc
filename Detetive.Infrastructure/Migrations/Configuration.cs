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

            if (!context.Armas.Any())
                context.Armas.AddOrUpdate(x => x.Id,
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

            if (!context.Locais.Any())
                context.Locais.AddOrUpdate(x => x.Id,
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

            if (!context.Suspeitos.Any())
                context.Suspeitos.AddOrUpdate(x => x.Id,
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

            if (!context.Casos.Any())
            {
                context.Casos.AddOrUpdate(x => x.Id, new Caso(1, 1, 1));
            }

            context.SaveChanges();

        }
    }
}
