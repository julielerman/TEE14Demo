namespace CustomerManagement.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name_FirstName = c.String(),
                        Name_LastName = c.String(),
                        InitialDate = c.DateTime(nullable: false),
                        Source = c.String(),
                        PrimaryAddress_Street1 = c.String(),
                        PrimaryAddress_Street2 = c.String(),
                        PrimaryAddress_City = c.String(),
                        PrimaryAddress_Region = c.String(),
                        PrimaryAddress_Country = c.String(),
                        PrimaryAddress_PostalCode = c.String(),
                        RowVersion = c.Binary(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
