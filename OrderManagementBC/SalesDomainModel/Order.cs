using System;
using System.Collections.Generic;
using System.Linq;
using SalesDomain.DomainEvents;
using Shared;
using Shared.Enums;
using Shared.ValueObjects;

namespace SalesDomain {
  public class Order : WritableEntity {
    private readonly List<LineItem> _lineItems;

    private Order(string firstName, string lastName, Address contactAddress, string source)
      : this(null) {
      Customer = Customer.CreateFromContact(Guid.Empty, contactAddress);
      _events.Add(new OrderCreatedWithNoExistingContact());
      SetShippingAddress(contactAddress);
      NewContactCustomerName = new Name(firstName, lastName);
      NewContactSource = source;
    }


    private Order(Guid contactId, Address contactAddress)
      : this(null) {
      Customer = Customer.CreateFromContact(contactId, contactAddress);
      SetShippingAddress(contactAddress);
    }

    private Order(Customer customer) : this() {
      //_lineItems = new List<LineItem>();
      if (customer != null) {
        CustomerId = customer.Id;
        SetShippingAddress(customer.PrimaryAddress);
      }
      ApplyCustomerStatusDiscount(customer);
    }


    protected Order() {
      _lineItems = new List<LineItem>();
      Id = Guid.NewGuid();
      OrderDate = DateTime.Now;
     
    }

    public DateTime OrderDate { get; private set; }
    public DateTime? DueDate { get; private set; }
    public bool OnlineOrder { get; private set; }
    public string PurchaseOrderNumber { get; private set; }
    public string Comment { get; private set; }
    public int PromotionId { get; private set; }
    //persisting the address used for this order in case
    //customer.shippingAddress changes in the future
    public Address ShippingAddress { get; private set; }

    public Name NewContactCustomerName { get; private set; } //not to be persisted
    public string NewContactSource { get; private set; }

    public double Discount {
      get { return CustomerDiscount + PromoDiscount; }
    }

    public double CustomerDiscount { get; private set; }
    public double PromoDiscount { get; private set; }

    public string SalesOrderNumber { get; private set; }

    public Guid CustomerId { get; private set; }
    //don't map customer navigation property in EF
    public Customer Customer { get; set; }
    public double SubTotal { get; private set; }

    public ICollection<LineItem> LineItems {
      get { return _lineItems; }
      // private set { _lineItems = value; }
    }

    public static Order CreateOrder(Customer customer) {
      return new Order(customer);
    }

    public static Order CreateOrderNewCustomer(Guid contactId, Address contactAddress) {
      var order = new Order(contactId, contactAddress);
      return order;
    }


    public static Order CreateOrderNewContact(string firstName, string lastName, Address contactAddress, string source) {
      return new Order(firstName, lastName, contactAddress, source);
    }


    public void CollectNameForNewCustomerContact(Name newContactName) {
      NewContactCustomerName = newContactName;
    }


    public void CreateLineItem(Guid productId, double listPrice, int quantity) {
      //NOTE: add some validations such as:
      //quantity can't be 0 and if it's >1000 give a discount
      // customer is a gold. give another discount
      var item = new LineItem
        (Id, productId, quantity, listPrice,
          CustomerDiscount + PromoDiscount);
      _lineItems.Add(item);
    }

    public void SetShippingAddress(Address address) {
      ShippingAddress = Address.CreateAddress(address.Street1, address.Street2, address.City,
        address.Region, address.Country, address.PostalCode);
    }


    public bool Validate() {
      if (LineItems.Any()) {
        return true;
      }
      return false;
    }


    public decimal CalculateShippingCost() {
      //items, quantity, price,disounts, total weight of item
      throw new NotImplementedException();
    }

    public void ApplyCustomerStatusDiscount(Customer customer) {
      var status = CustomerStatus.New;
      if (customer != null)
        status = customer.Status;
      switch (status) {
        case CustomerStatus.Silver:
          CustomerDiscount = CustomerDiscounts.SilverDiscount;
          break;
        case CustomerStatus.Gold:
          CustomerDiscount = CustomerDiscounts.GoldDiscount;
          break;
        case CustomerStatus.Platinum:
          CustomerDiscount = CustomerDiscounts.PlatinumDiscount;
          break;
        default:
        {
          CustomerDiscount = 0;
          break;
        }
      }
    }

    public void SetOrderDetails(bool onLineOrder, string PONumber, string comment, int promotionId, double promoDiscount) {
      OnlineOrder = onLineOrder;
      PurchaseOrderNumber = PONumber;
      Comment = comment;

      PromotionId = promotionId;
      PromoDiscount = promoDiscount;
    }
  }
}