namespace CustomerManagement.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contacts", "ModifiedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ModifiedDate");
            DropColumn("dbo.Contacts", "CreatedDate");
        }
    }
}
