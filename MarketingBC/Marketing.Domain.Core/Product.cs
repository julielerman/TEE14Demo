using System.Collections.Generic;

namespace Marketing.Domain.Core
{
  //not fleshed out yet for DDD
  public class Product
  {
  
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string ProductNumber { get; private set; }
    public List<Category> Categories { get; private set; }
   
}
}