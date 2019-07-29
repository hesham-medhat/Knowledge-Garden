namespace Knowledge_Garden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNotificationsBridge : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Flowers", "Owner_Username", "dbo.Employees");
            DropIndex("dbo.Flowers", new[] { "Owner_Username" });
            RenameColumn(table: "dbo.Flowers", name: "Owner_Username", newName: "OwnerUsername");
            RenameColumn(table: "dbo.Employees", name: "UserId_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Employees", name: "IX_UserId_Id", newName: "IX_ApplicationUser_Id");
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        EmployeeUsername = c.String(nullable: false, maxLength: 128),
                        FlowerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeUsername, t.FlowerId })
                .ForeignKey("dbo.Employees", t => t.EmployeeUsername, cascadeDelete: true)
                .ForeignKey("dbo.Flowers", t => t.FlowerId, cascadeDelete: true)
                .Index(t => t.EmployeeUsername)
                .Index(t => t.FlowerId);
            
            AlterColumn("dbo.Flowers", "OwnerUsername", c => c.String(maxLength: 128));
            CreateIndex("dbo.Flowers", "OwnerUsername");
            AddForeignKey("dbo.Flowers", "OwnerUsername", "dbo.Employees", "Username");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flowers", "OwnerUsername", "dbo.Employees");
            DropForeignKey("dbo.Notifications", "FlowerId", "dbo.Flowers");
            DropForeignKey("dbo.Notifications", "EmployeeUsername", "dbo.Employees");
            DropIndex("dbo.Notifications", new[] { "FlowerId" });
            DropIndex("dbo.Notifications", new[] { "EmployeeUsername" });
            DropIndex("dbo.Flowers", new[] { "OwnerUsername" });
            AlterColumn("dbo.Flowers", "OwnerUsername", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.Notifications");
            RenameIndex(table: "dbo.Employees", name: "IX_ApplicationUser_Id", newName: "IX_UserId_Id");
            RenameColumn(table: "dbo.Employees", name: "ApplicationUser_Id", newName: "UserId_Id");
            RenameColumn(table: "dbo.Flowers", name: "OwnerUsername", newName: "Owner_Username");
            CreateIndex("dbo.Flowers", "Owner_Username");
            AddForeignKey("dbo.Flowers", "Owner_Username", "dbo.Employees", "Username", cascadeDelete: true);
        }
    }
}
