namespace SalesOrder.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(),
                        OnlineOrder = c.Boolean(nullable: false),
                        PurchaseOrderNumber = c.String(),
                        Comment = c.String(),
                        PromotionId = c.Int(nullable: false),
                        ShippingAddress_Street1 = c.String(),
                        ShippingAddress_Street2 = c.String(),
                        ShippingAddress_City = c.String(),
                        ShippingAddress_Region = c.String(),
                        ShippingAddress_Country = c.String(),
                        ShippingAddress_PostalCode = c.String(),
                        CustomerDiscount = c.Double(nullable: false),
                        PromoDiscount = c.Double(nullable: false),
                        SalesOrderNumber = c.String(),
                        CustomerId = c.Guid(nullable: false),
                        SubTotal = c.Double(nullable: false),
                        RowVersion = c.Binary(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ContactId = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.LineItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        OrderQty = c.Int(nullable: false),
                        UnitPrice = c.Double(),
                        UnitPriceDiscount = c.Double(),
                        ShipmentId = c.Int(),
                        RowVersion = c.Binary(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LineItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.LineItems", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.LineItems");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
        }
    }
}
