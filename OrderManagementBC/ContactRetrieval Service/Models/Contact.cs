using System;

namespace OrderManagement.DataMirroring.Models {
  public class Contact {
    public Guid ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}