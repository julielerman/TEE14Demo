using System;
using Shared;
using Shared.Enums;

namespace SalesDomain {
  //in this bounded context, product is immutable
  //but it can be identified soley by its Id
  //populated from service
  //reference context in EF
  public class Product : ReadOnlyEntity {
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string ProductNumber { get; private set; }
    public ProductColor Color { get; private set; }
    public double ListPrice { get; private set; }
    public string Size { get; private set; }
    public bool CurrentPromotionId { get; private set; }
    public double? ShippingWeight { get; private set; }

    public byte[] Photo { get; private set; }
  }
}