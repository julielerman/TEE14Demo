using System.Data.Entity;
using ProductManagement.Core;

namespace ProductManagement.Persistence
{
  public class ProductContext:DbContext
  {
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      modelBuilder.HasDefaultSchema("Product");
      base.OnModelCreating(modelBuilder);
    }
  }
}
