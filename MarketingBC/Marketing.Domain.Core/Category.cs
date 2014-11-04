using System.Collections.Generic;

namespace Marketing.Domain.Core {
  //not fleshed out yet for DDD
  public class Category  {
   
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<Product> Products { get; private set; }
  
  }
}