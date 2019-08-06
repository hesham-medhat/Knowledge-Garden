namespace Knowledge_Garden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContentTypeToFiles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attachments", "ContentType", c => c.String(nullable: false));
            AddColumn("dbo.TempFiles", "ContentType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TempFiles", "ContentType");
            DropColumn("dbo.Attachments", "ContentType");
        }
    }
}
