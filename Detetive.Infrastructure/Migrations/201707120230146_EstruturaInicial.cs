namespace Detetive.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstruturaInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Armas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Casos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DataAbertura = c.DateTime(nullable: false),
                        SuspeitoID = c.Int(nullable: false),
                        LocalID = c.Int(nullable: false),
                        ArmaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Armas", t => t.ArmaID)
                .ForeignKey("dbo.Locais", t => t.LocalID)
                .ForeignKey("dbo.Suspeitos", t => t.SuspeitoID)
                .Index(t => t.SuspeitoID)
                .Index(t => t.LocalID)
                .Index(t => t.ArmaID);
            
            CreateTable(
                "dbo.Locais",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Suspeitos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Casos", "SuspeitoID", "dbo.Suspeitos");
            DropForeignKey("dbo.Casos", "LocalID", "dbo.Locais");
            DropForeignKey("dbo.Casos", "ArmaID", "dbo.Armas");
            DropIndex("dbo.Casos", new[] { "ArmaID" });
            DropIndex("dbo.Casos", new[] { "LocalID" });
            DropIndex("dbo.Casos", new[] { "SuspeitoID" });
            DropTable("dbo.Suspeitos");
            DropTable("dbo.Locais");
            DropTable("dbo.Casos");
            DropTable("dbo.Armas");
        }
    }
}
