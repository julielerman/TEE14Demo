using System;
using Shared;

namespace SalesDomain {
  public class LineItem : WritableEntity {
    private LineItem() {
    }

    public LineItem(Guid orderId, Guid productId, int quantity, double unitPrice, double unitPriceDiscount) {
      Id = Guid.NewGuid();
      OrderId = orderId;
      OrderQty = quantity;
      ProductId = productId;
      UnitPrice = unitPrice;
      UnitPriceDiscount = unitPriceDiscount;
    }

    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }

    public int OrderQty { get; private set; }
    public double? UnitPrice { get; private set; }
    public double? UnitPriceDiscount { get; private set; }


    public double LineTotal {
      get {
        if (UnitPrice != null) {
          if (UnitPriceDiscount != null)
            return OrderQty*(UnitPrice.Value*(1 - UnitPriceDiscount.Value));
        }
        return 0;
      }
    }


    public int? ShipmentId { get; set; }

    public void AdjustQuantity(int quantity) {
      OrderQty = quantity;
    }
  }
}