using System;

namespace CustomerManagement.Core.Services {
  public class CustomerDto {
    //  public static CustomerDto Create(Guid customerId, string clientName, bool isNew)
    //  {
    //    return new CustomerDto(customerId, clientName, isNew);
    //  }

    //  private CustomerDto(Guid customerId, string clientName, bool isNew)
    //  {
    //    CustomerId = customerId;
    //    ClientName = clientName;
    //    IsNew = isNew;

    //  }
    //  public Guid CustomerId { get; set; }
    //  public string ClientName { get; set; }
    //  public bool IsNew { get; set; }
    //}

    private CustomerDto(Guid customerId, string clientName) {
      CustomerId = customerId;
      ClientName = clientName;
    }

    public Guid CustomerId { get; set; }
    public string ClientName { get; set; }

    public static CustomerDto Create(Guid customerId, string clientName) {
      return new CustomerDto(customerId, clientName);
    }
  }
}