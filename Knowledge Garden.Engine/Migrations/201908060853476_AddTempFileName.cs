namespace Knowledge_Garden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTempFileName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TempFiles", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TempFiles", "Name");
        }
    }
}
