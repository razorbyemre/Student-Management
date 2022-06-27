namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Message", "To", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Message", "To");
        }
    }
}
