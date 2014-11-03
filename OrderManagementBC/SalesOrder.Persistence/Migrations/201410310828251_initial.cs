using System.Data.Entity.Migrations;

namespace SalesOrder.Persistence.Migrations {
  public partial class initial : DbMigration {
    public override void Up() {
      CreateTable(
        "dbo.Orders",
        c => new {
          Id = c.Guid(false),
          OrderDate = c.DateTime(false),
          DueDate = c.DateTime(),
          OnlineOrder = c.Boolean(false),
          PurchaseOrderNumber = c.String(),
          Comment = c.String(),
          PromotionId = c.Int(false),
          ShippingAddress_Street1 = c.String(),
          ShippingAddress_Street2 = c.String(),
          ShippingAddress_City = c.String(),
          ShippingAddress_Region = c.String(),
          ShippingAddress_Country = c.String(),
          ShippingAddress_PostalCode = c.String(),
          CustomerDiscount = c.Double(false),
          PromoDiscount = c.Double(false),
          SalesOrderNumber = c.String(),
          CustomerId = c.Guid(false),
          SubTotal = c.Double(false),
          RowVersion = c.Binary(),
        })
        .PrimaryKey(t => t.Id)
        .ForeignKey("dbo.Customers", t => t.CustomerId, true)
        .Index(t => t.CustomerId);

      CreateTable(
        "dbo.Customers",
        c => new {
          Id = c.Guid(false),
          ContactId = c.Guid(false),
          Status = c.Int(false),
          PrimaryAddress_Street1 = c.String(),
          PrimaryAddress_Street2 = c.String(),
          PrimaryAddress_City = c.String(),
          PrimaryAddress_Region = c.String(),
          PrimaryAddress_Country = c.String(),
          PrimaryAddress_PostalCode = c.String(),
          RowVersion = c.Binary(),
        })
        .PrimaryKey(t => t.Id);

      CreateTable(
        "dbo.LineItems",
        c => new {
          Id = c.Guid(false),
          OrderId = c.Guid(false),
          ProductId = c.Guid(false),
          OrderQty = c.Int(false),
          UnitPrice = c.Double(),
          UnitPriceDiscount = c.Double(),
          ShipmentId = c.Int(),
          RowVersion = c.Binary(),
        })
        .PrimaryKey(t => t.Id)
        .ForeignKey("dbo.Orders", t => t.OrderId, true)
        .Index(t => t.OrderId);
    }

    public override void Down() {
      DropForeignKey("dbo.LineItems", "OrderId", "dbo.Orders");
      DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
      DropIndex("dbo.LineItems", new[] {"OrderId"});
      DropIndex("dbo.Orders", new[] {"CustomerId"});
      DropTable("dbo.LineItems");
      DropTable("dbo.Customers");
      DropTable("dbo.Orders");
    }
  }
}