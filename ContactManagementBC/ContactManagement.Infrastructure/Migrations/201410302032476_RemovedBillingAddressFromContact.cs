using System.Data.Entity.Migrations;

namespace CustomerManagement.Infrastructure.Migrations {
  public partial class RemovedBillingAddressFromContact : DbMigration {
    public override void Up() {
      DropColumn("dbo.Contacts", "BillingAddress_Street1");
      DropColumn("dbo.Contacts", "BillingAddress_Street2");
      DropColumn("dbo.Contacts", "BillingAddress_City");
      DropColumn("dbo.Contacts", "BillingAddress_Region");
      DropColumn("dbo.Contacts", "BillingAddress_Country");
      DropColumn("dbo.Contacts", "BillingAddress_PostalCode");
    }

    public override void Down() {
      AddColumn("dbo.Contacts", "BillingAddress_PostalCode", c => c.String());
      AddColumn("dbo.Contacts", "BillingAddress_Country", c => c.String());
      AddColumn("dbo.Contacts", "BillingAddress_Region", c => c.String());
      AddColumn("dbo.Contacts", "BillingAddress_City", c => c.String());
      AddColumn("dbo.Contacts", "BillingAddress_Street2", c => c.String());
      AddColumn("dbo.Contacts", "BillingAddress_Street1", c => c.String());
    }
  }
}