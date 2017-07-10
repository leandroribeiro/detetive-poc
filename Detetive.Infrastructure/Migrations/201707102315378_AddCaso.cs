namespace Detetive.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCaso : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Casos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Arma_ID = c.Int(),
                        Local_ID = c.Int(),
                        Suspeito_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Armas", t => t.Arma_ID)
                .ForeignKey("dbo.Locais", t => t.Local_ID)
                .ForeignKey("dbo.Suspeitos", t => t.Suspeito_ID)
                .Index(t => t.Arma_ID)
                .Index(t => t.Local_ID)
                .Index(t => t.Suspeito_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Casos", "Suspeito_ID", "dbo.Suspeitos");
            DropForeignKey("dbo.Casos", "Local_ID", "dbo.Locais");
            DropForeignKey("dbo.Casos", "Arma_ID", "dbo.Armas");
            DropIndex("dbo.Casos", new[] { "Suspeito_ID" });
            DropIndex("dbo.Casos", new[] { "Local_ID" });
            DropIndex("dbo.Casos", new[] { "Arma_ID" });
            DropTable("dbo.Casos");
        }
    }
}
