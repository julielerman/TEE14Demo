using System.Data.Entity.Migrations;

namespace OrderManagement.DataMirroring.Migrations {
  public partial class InitialCreate : DbMigration {
    public override void Up() {
      CreateTable(
        "dbo.Contacts",
        c => new {
          ContactId = c.Guid(false),
          FirstName = c.String(),
          LastName = c.String(),
        })
        .PrimaryKey(t => t.ContactId);
    }

    public override void Down() {
      DropTable("dbo.Contacts");
    }
  }
}