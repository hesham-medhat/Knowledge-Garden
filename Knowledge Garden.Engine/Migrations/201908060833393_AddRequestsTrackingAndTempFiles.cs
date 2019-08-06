namespace Knowledge_Garden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequestsTrackingAndTempFiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        OwnerUsername = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.OwnerUsername, cascadeDelete: true)
                .Index(t => t.OwnerUsername);
            
            CreateTable(
                "dbo.TempFiles",
                c => new
                    {
                        RequestId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        blobValue = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => new { t.RequestId, t.Id })
                .ForeignKey("dbo.Requests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TempFiles", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.Requests", "OwnerUsername", "dbo.Employees");
            DropIndex("dbo.TempFiles", new[] { "RequestId" });
            DropIndex("dbo.Requests", new[] { "OwnerUsername" });
            DropTable("dbo.TempFiles");
            DropTable("dbo.Requests");
        }
    }
}
