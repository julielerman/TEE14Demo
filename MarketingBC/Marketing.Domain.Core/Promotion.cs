using System;
using System.Collections.Generic;

namespace Marketing.Domain.Core
{
  //not fleshed out yet for DDD
  public class Promotion
  {
    public Promotion()
    {
      Products = new List<Product>();
      Categories = new List<Category>();
    }
    public int PromotionId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Discount { get; set; }
    public String Name { get; set; }
    public String Description { get; set; }
    public bool AllProducts { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<Category> Categories { get; set; }

  }
}