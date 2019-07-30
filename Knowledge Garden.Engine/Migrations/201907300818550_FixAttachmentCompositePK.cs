namespace Knowledge_Garden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixAttachmentCompositePK : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Attachments", name: "Flower_Id", newName: "FlowerId");
            RenameIndex(table: "dbo.Attachments", name: "IX_Flower_Id", newName: "IX_FlowerId");
            DropPrimaryKey("dbo.Attachments");
            AddPrimaryKey("dbo.Attachments", new[] { "FlowerId", "Name" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Attachments");
            AddPrimaryKey("dbo.Attachments", "Name");
            RenameIndex(table: "dbo.Attachments", name: "IX_FlowerId", newName: "IX_Flower_Id");
            RenameColumn(table: "dbo.Attachments", name: "FlowerId", newName: "Flower_Id");
        }
    }
}
