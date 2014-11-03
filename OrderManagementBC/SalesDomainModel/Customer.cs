using System;
using System.Collections.Generic;
using Shared;
using Shared.Enums;
using Shared.Interfaces;
using Shared.ValueObjects;

namespace SalesDomain {
  public class Customer : WritableEntity {
    public Customer() {
    }

    private Customer(Guid contactId) {
      Id = Guid.NewGuid();

      ContactId = contactId;
      Status = CustomerStatus.New;
      CreatedDate = DateTime.Now.Date;
    }

    public ICollection<IDomainEvent> Events { get; private set; }
    public Guid ContactId { get; private set; }
    //don't map contact property in EF
    public Contact Contact { get; private set; }
    public CustomerStatus Status { get; private set; }
    public Address PrimaryAddress { get; private set; }

    public static Customer CreateFromContact(Guid contactId, Address primaryAddress) {
      var customer = new Customer(contactId);
      customer.PrimaryAddress = primaryAddress;
      return customer;
    }

    public static Customer CreateNoExistingContact() {
      return new Customer(Guid.Empty);
    }

    public void SetPrimaryAddress(Address address) {
      PrimaryAddress = address;
    }
  }
}