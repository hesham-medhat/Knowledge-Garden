namespace Knowledge_Garden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInitialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Flower_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Flowers", t => t.Flower_Id, cascadeDelete: true)
                .Index(t => t.Flower_Id);
            
            CreateTable(
                "dbo.Flowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Problem = c.String(nullable: false, storeType: "ntext"),
                        Solution = c.String(storeType: "ntext"),
                        LastUpdateDate = c.DateTime(nullable: false),
                        Owner_Username = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Owner_Username, cascadeDelete: true)
                .Index(t => t.Owner_Username);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        LastContributionTime = c.DateTime(),
                        UserId_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Username)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id, cascadeDelete: true)
                .Index(t => t.UserId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attachments", "Flower_Id", "dbo.Flowers");
            DropForeignKey("dbo.Flowers", "Owner_Username", "dbo.Employees");
            DropForeignKey("dbo.Employees", "UserId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "UserId_Id" });
            DropIndex("dbo.Flowers", new[] { "Owner_Username" });
            DropIndex("dbo.Attachments", new[] { "Flower_Id" });
            DropTable("dbo.Employees");
            DropTable("dbo.Flowers");
            DropTable("dbo.Attachments");
        }
    }
}
