using System.Collections.Generic;

namespace ProductManagement.Core {
  public class Category  {
    public Category() {
      Products=new List<Product>();
    }

    private Category(string name) {
      Name = name;
     }
    public int Id { get; set; }
    public string Name { get;  set; }
    public List<Product> Products { get; set; }
    public static Category Create(string name) {
      return new Category(name);
    }
  }
}