using System.Collections.Generic;

namespace Marketing.Domain.Core {
  public class Category  {
   
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<Product> Products { get; private set; }
  
  }
}