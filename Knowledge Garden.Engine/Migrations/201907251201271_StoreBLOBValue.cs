namespace Knowledge_Garden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoreBLOBValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attachments", "blobValue", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attachments", "blobValue");
        }
    }
}
