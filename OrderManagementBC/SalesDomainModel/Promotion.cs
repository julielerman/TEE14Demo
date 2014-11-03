using System;
using Shared;

namespace SalesDomain {
  public class CurrentPromotion : ReadOnlyEntity {
    public double Discount { get; set; }
    public String Name { get; set; }
    public String Description { get; set; }
  }
}