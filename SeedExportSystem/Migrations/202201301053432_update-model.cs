namespace SeedExportSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exports", "PredmetId", c => c.Int(nullable: false));
            CreateIndex("dbo.Exports", "PredmetId");
            AddForeignKey("dbo.Exports", "PredmetId", "dbo.Predmets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exports", "PredmetId", "dbo.Predmets");
            DropIndex("dbo.Exports", new[] { "PredmetId" });
            DropColumn("dbo.Exports", "PredmetId");
        }
    }
}
