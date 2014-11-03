using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesDomain;
using SalesDomain.DomainEvents;
using Shared.ValueObjects;

namespace SalesOrder.Tests {
  [TestClass]
  public class SalesCreateShould {
    [TestMethod]
    public void AcceptExistingCustomer() {
      //arrange
      Customer customer = Customer.CreateFromContact(Guid.NewGuid(), TheAddress());
      Order order = Order.CreateOrder(customer);
      Assert.AreEqual(TheAddress(), order.ShippingAddress);
      Assert.AreEqual(0, order.Discount);
    }

    [TestMethod]
    public void AcceptExistingContactNoCustomer() {
      Order order = Order.CreateOrderNewCustomer(Guid.NewGuid(), TheAddress());
      Assert.AreEqual(TheAddress(), order.ShippingAddress);
      Assert.AreEqual(0, order.Discount);
    }

    [TestMethod]
    public void AcceptNoContactNoCustomer() {
      Order order = Order.CreateOrderNewContact("Pranav", "Rastogi", TheAddress(), "Friends");
      Assert.AreEqual(0, order.Discount);
      Assert.AreEqual(1, order.Events.Count);
    }

    [TestMethod]
    public void ContainContactAddressNewCustomerExistingContact() {
      Guid contactId = Guid.NewGuid();
      Order order = Order.CreateOrderNewCustomer(contactId, TheAddress());
      Assert.AreEqual(TheAddress(), order.ShippingAddress);
      Assert.AreEqual(contactId, order.Customer.ContactId);
    }


    [TestMethod]
    public void ContainCorrectEventForNewCustomerNewContact() {
      Order order = Order.CreateOrderNewContact("Pranav", "Rastogi", TheAddress(), "Friends");
      Assert.AreEqual(typeof (OrderCreatedWithNoExistingContact), order.Events.FirstOrDefault().GetType());
    }

    [TestMethod]
    public void ContainStoredNameForNewCustomerNewContact() {
      Order order = Order.CreateOrderNewContact("Pranav", "Rastogi", TheAddress(), "Friends");
      Assert.AreEqual("Pranav", order.NewContactCustomerName.FirstName);
    }

    private static Address TheAddress() {
      var address = Address.CreateAddress("1 Orbit Way", "", "Orbit CIty", "O", "RB", "");
      return address;
    }
  }
}