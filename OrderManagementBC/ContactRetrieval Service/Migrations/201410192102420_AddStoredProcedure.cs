using System.Data.Entity.Migrations;

namespace OrderManagement.DataMirroring.Migrations {
  public partial class AddStoredProcedure : DbMigration {
    public override void Up() {
      CreateStoredProcedure("ReplaceContact",
        c => new {Id = c.Guid(), FirstName = c.String(50), LastName = c.String(50)},
        "DELETE from Contacts where ContactId=@id " +
        "INSERT into Contacts Values(@Id,@FirstName,@LastName) "
        );
    }

    public override void Down() {
      DropStoredProcedure("ReplaceContact");
    }
  }
}