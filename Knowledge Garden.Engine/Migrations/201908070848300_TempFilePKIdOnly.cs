namespace Knowledge_Garden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TempFilePKIdOnly : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TempFiles");
            AlterColumn("dbo.TempFiles", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TempFiles", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TempFiles");
            AlterColumn("dbo.TempFiles", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TempFiles", new[] { "RequestId", "Id" });
        }
    }
}
