using System.Collections.Generic;
using System.Data.Entity.Migrations;
using ProductManagement.Core;

namespace ProductManagement.Persistence.Migrations {
  internal sealed class Configuration : DbMigrationsConfiguration<ProductContext> {
    public Configuration() {
      AutomaticMigrationsEnabled = false;
      ContextKey = "Product";
    }

    protected override void Seed(ProductContext context) {
      context.Categories.AddOrUpdate(
      new Category {
          Name = "Costume",
          Products = new List<Product> {
            (Product.Create("Skeleton", "CSKT-1")),
            (Product.Create("Ninja", "CNJN-1")),
            (Product.Create("Wonder Woman", "CWWO-1"))
          }
        },
         new Category
         {
           Name = "Makeup",
           Products = new List<Product> {
            (Product.Create("White Face Paint", "MWFP-1")),
            (Product.Create("Black Face Paint", "MBFP-1")),
            (Product.Create("Red Face Paint", "MRFP-1"))
          }
         },
        new Category {
          Name = "Candy",
          Products = new List<Product> {
            (Product.Create("M&Ms", "CMM-1")),
            (Product.Create("Snickers", "CSN-1")),
            (Product.Create("Twix", "CTWX-1"))
          }
        },
        new Category {
          Name = "Decorations",
          Products = new List<Product> {
            (Product.Create("Orange Streamers", "DOS-1")),
            (Product.Create("Black Streamers", "DBS-1"))
          }
        }
        );
    }
  }
}