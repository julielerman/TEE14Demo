using System.Data.Entity.Migrations;

namespace CustomerManagement.Infrastructure.Migrations {
  public partial class InitialCreate : DbMigration {
    public override void Up() {
      CreateTable(
        "dbo.Contacts",
        c => new {
          Id = c.Guid(false),
          Name_FirstName = c.String(),
          Name_LastName = c.String(),
          InitialDate = c.DateTime(false),
          ModifiedDate = c.DateTime(false),
          Source = c.String(),
          Address_Street1 = c.String(),
          Address_Street2 = c.String(),
          Address_City = c.String(),
          Address_Region = c.String(),
          Address_Country = c.String(),
          Address_PostalCode = c.String(),
          BillingAddress_Street1 = c.String(),
          BillingAddress_Street2 = c.String(),
          BillingAddress_City = c.String(),
          BillingAddress_Region = c.String(),
          BillingAddress_Country = c.String(),
          BillingAddress_PostalCode = c.String(),
        })
        .PrimaryKey(t => t.Id);
    }

    public override void Down() {
      DropTable("dbo.Contacts");
    }
  }
}