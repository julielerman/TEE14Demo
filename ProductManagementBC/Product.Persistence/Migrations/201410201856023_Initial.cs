namespace ProductManagement.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Product.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Product.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProductNumber = c.String(),
                        Color = c.Int(nullable: false),
                        StandardCost = c.Double(nullable: false),
                        ListPrice = c.Double(nullable: false),
                        Size = c.String(),
                        SellStartDate = c.DateTime(nullable: false),
                        ShippingWeight = c.Double(),
                        SellEndDate = c.DateTime(),
                        DiscontinuedDate = c.DateTime(),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Product.ProductCategories",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Category_Id })
                .ForeignKey("Product.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("Product.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Product.ProductCategories", "Category_Id", "Product.Categories");
            DropForeignKey("Product.ProductCategories", "Product_Id", "Product.Products");
            DropIndex("Product.ProductCategories", new[] { "Category_Id" });
            DropIndex("Product.ProductCategories", new[] { "Product_Id" });
            DropTable("Product.ProductCategories");
            DropTable("Product.Products");
            DropTable("Product.Categories");
        }
    }
}
