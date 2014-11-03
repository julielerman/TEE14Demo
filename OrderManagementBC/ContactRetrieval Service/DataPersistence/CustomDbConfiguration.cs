using System.Data.Entity;
using OrderManagement.DataMirroring.Migrations;

namespace OrderManagement.DataMirroring.DataPersistence {
  public class CustomDbConfiguration : DbConfiguration {
    public CustomDbConfiguration() {
      //With this set here, running the windows service (really a console app),
      //will cause Entity Framework to execute the migrations:
      //initial will create the database and its base schema
      //AddStoredProcedure will add a sproc to the database

      SetDatabaseInitializer(new MigrateDatabaseToLatestVersion<ContactsContext,
        Configuration>());
    }
  }
}