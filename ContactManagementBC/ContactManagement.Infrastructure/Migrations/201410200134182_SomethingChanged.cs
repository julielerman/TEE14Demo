using System.Data.Entity.Migrations;

namespace CustomerManagement.Infrastructure.Migrations {
  public partial class SomethingChanged : DbMigration {
    public override void Up() {
      AddColumn("dbo.Contacts", "PrimaryAddress_Street1", c => c.String());
      AddColumn("dbo.Contacts", "PrimaryAddress_Street2", c => c.String());
      AddColumn("dbo.Contacts", "PrimaryAddress_City", c => c.String());
      AddColumn("dbo.Contacts", "PrimaryAddress_Region", c => c.String());
      AddColumn("dbo.Contacts", "PrimaryAddress_Country", c => c.String());
      AddColumn("dbo.Contacts", "PrimaryAddress_PostalCode", c => c.String());
      AddColumn("dbo.Contacts", "RowVersion", c => c.Binary());
      AddColumn("dbo.Contacts", "CreatedDate", c => c.DateTime(false));
      DropColumn("dbo.Contacts", "Address_Street1");
      DropColumn("dbo.Contacts", "Address_Street2");
      DropColumn("dbo.Contacts", "Address_City");
      DropColumn("dbo.Contacts", "Address_Region");
      DropColumn("dbo.Contacts", "Address_Country");
      DropColumn("dbo.Contacts", "Address_PostalCode");
    }

    public override void Down() {
      AddColumn("dbo.Contacts", "Address_PostalCode", c => c.String());
      AddColumn("dbo.Contacts", "Address_Country", c => c.String());
      AddColumn("dbo.Contacts", "Address_Region", c => c.String());
      AddColumn("dbo.Contacts", "Address_City", c => c.String());
      AddColumn("dbo.Contacts", "Address_Street2", c => c.String());
      AddColumn("dbo.Contacts", "Address_Street1", c => c.String());
      DropColumn("dbo.Contacts", "CreatedDate");
      DropColumn("dbo.Contacts", "RowVersion");
      DropColumn("dbo.Contacts", "PrimaryAddress_PostalCode");
      DropColumn("dbo.Contacts", "PrimaryAddress_Country");
      DropColumn("dbo.Contacts", "PrimaryAddress_Region");
      DropColumn("dbo.Contacts", "PrimaryAddress_City");
      DropColumn("dbo.Contacts", "PrimaryAddress_Street2");
      DropColumn("dbo.Contacts", "PrimaryAddress_Street1");
    }
  }
}