namespace SeedExportSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewDbBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atributs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        PredmetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Predmets", t => t.PredmetId, cascadeDelete: true)
                .Index(t => t.PredmetId);
            
            CreateTable(
                "dbo.Predmets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Qiymats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        AtributId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Atributs", t => t.AtributId, cascadeDelete: true)
                .Index(t => t.AtributId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Qiymats", "AtributId", "dbo.Atributs");
            DropForeignKey("dbo.Atributs", "PredmetId", "dbo.Predmets");
            DropIndex("dbo.Qiymats", new[] { "AtributId" });
            DropIndex("dbo.Atributs", new[] { "PredmetId" });
            DropTable("dbo.Qiymats");
            DropTable("dbo.Predmets");
            DropTable("dbo.Atributs");
        }
    }
}
