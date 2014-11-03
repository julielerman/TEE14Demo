using System;
using System.Data.Entity;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesDomain;
using SalesOrder.Persistence;
using Shared.ValueObjects;

namespace SalesOrder.Tests {
  [TestClass]
  public class SalesOrderRepoShould {
    public SalesOrderRepoShould() {
      //Note: these integration tests will run a migrations check every time so that
      //test database can be created if necessary.
      //You can disable that if the db is there and you want to let these run more quickly
      Database.SetInitializer(new NullDatabaseInitializer<OrderAggregateContext>());
    }

    [TestMethod]
    public void BeAbleToCallWebApi() {
      var repo = new OrderAggregateRepository();
      Order order = Order.CreateOrderNewContact("Julie", "Lerman", TheAddress(), "Friend");
      try {
        Guid result = repo.GetNewContactIdFromContactApi(order).Result;
      }
      catch (Exception ex) {
        if ((ex.InnerException).InnerException.Message.Contains("Unable to connect to the remote server")) {
          Assert.Fail(
            "You need to run the Contact Management Services API project to run the SalesOrder Repo Tests. Run that without debugging (e.g. CTRL+F5 or Ctrl+Shift+W). Note that debugging the tests will start that up for you.");
        }
        throw;
      }


      Assert.IsTrue(true);
    }

    [TestMethod]
    public void ReturnDataGetNewContactIdFromContactApi() {
      var repo = new OrderAggregateRepository();
      Order order = Order.CreateOrderNewContact("Julie", "Lerman", TheAddress(), "Friend");

      Guid result = repo.GetNewContactIdFromContactApi(order).Result;
      Assert.AreNotEqual(Guid.Empty, result);
    }

    [TestMethod]
    public void SaveNewOrderWithNewCustomer() {
      var repo = new OrderAggregateRepository();
      Order order = Order.CreateOrderNewCustomer(Guid.NewGuid(), TheAddress());
      order.SetOrderDetails(false, "abcde", "good order", 0, 0);
      order.CreateLineItem(Guid.NewGuid(), 5.55, 2);

      bool result = repo.Update(order).Result;
      Debug.WriteLine(order.Customer.ContactId);
      Assert.AreNotEqual(Guid.Empty, order.Customer.ContactId);
    }

    [TestMethod]
    public void SaveNewOrderWithNewContact() {
      var repo = new OrderAggregateRepository();
      Order order = Order.CreateOrderNewContact("Julie", "Lerman", TheAddress(), "Friend");
      order.SetOrderDetails(false, "abcde", "good order", 0, 0);
      order.CreateLineItem(Guid.NewGuid(), 5.55, 2);

      bool result = repo.Update(order).Result;
      Assert.AreNotEqual(Guid.Empty, result);
    }

    private static Address TheAddress() {
      var address = Address.CreateAddress("1 Orbit Way", "", "Orbit CIty", "O", "RB", "");
      return address;
    }
  }
}