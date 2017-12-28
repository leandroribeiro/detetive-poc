namespace Detetive.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoPropriedadesDeAuditoria : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Casos", new[] { "SuspeitoID" });
            DropIndex("dbo.Casos", new[] { "LocalID" });
            DropIndex("dbo.Casos", new[] { "ArmaID" });
            AddColumn("dbo.Armas", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Armas", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Armas", "CreatedBy", c => c.String());
            AddColumn("dbo.Armas", "ModifiedBy", c => c.String());
            AddColumn("dbo.Armas", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Casos", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Casos", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Casos", "CreatedBy", c => c.String());
            AddColumn("dbo.Casos", "ModifiedBy", c => c.String());
            AddColumn("dbo.Casos", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Locais", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Locais", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Locais", "CreatedBy", c => c.String());
            AddColumn("dbo.Locais", "ModifiedBy", c => c.String());
            AddColumn("dbo.Locais", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Suspeitos", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Suspeitos", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Suspeitos", "CreatedBy", c => c.String());
            AddColumn("dbo.Suspeitos", "ModifiedBy", c => c.String());
            AddColumn("dbo.Suspeitos", "Version", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            CreateIndex("dbo.Casos", "SuspeitoId");
            CreateIndex("dbo.Casos", "LocalId");
            CreateIndex("dbo.Casos", "ArmaId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Casos", new[] { "ArmaId" });
            DropIndex("dbo.Casos", new[] { "LocalId" });
            DropIndex("dbo.Casos", new[] { "SuspeitoId" });
            DropColumn("dbo.Suspeitos", "Version");
            DropColumn("dbo.Suspeitos", "ModifiedBy");
            DropColumn("dbo.Suspeitos", "CreatedBy");
            DropColumn("dbo.Suspeitos", "ModifiedDate");
            DropColumn("dbo.Suspeitos", "CreatedDate");
            DropColumn("dbo.Locais", "Version");
            DropColumn("dbo.Locais", "ModifiedBy");
            DropColumn("dbo.Locais", "CreatedBy");
            DropColumn("dbo.Locais", "ModifiedDate");
            DropColumn("dbo.Locais", "CreatedDate");
            DropColumn("dbo.Casos", "Version");
            DropColumn("dbo.Casos", "ModifiedBy");
            DropColumn("dbo.Casos", "CreatedBy");
            DropColumn("dbo.Casos", "ModifiedDate");
            DropColumn("dbo.Casos", "CreatedDate");
            DropColumn("dbo.Armas", "Version");
            DropColumn("dbo.Armas", "ModifiedBy");
            DropColumn("dbo.Armas", "CreatedBy");
            DropColumn("dbo.Armas", "ModifiedDate");
            DropColumn("dbo.Armas", "CreatedDate");
            CreateIndex("dbo.Casos", "ArmaID");
            CreateIndex("dbo.Casos", "LocalID");
            CreateIndex("dbo.Casos", "SuspeitoID");
        }
    }
}
