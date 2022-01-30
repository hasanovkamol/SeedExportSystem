namespace SeedExportSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KeyValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        isResult = c.Boolean(nullable: false),
                        Export_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exports", t => t.Export_Id)
                .Index(t => t.Export_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KeyValues", "Export_Id", "dbo.Exports");
            DropIndex("dbo.KeyValues", new[] { "Export_Id" });
            DropTable("dbo.KeyValues");
            DropTable("dbo.Exports");
        }
    }
}
