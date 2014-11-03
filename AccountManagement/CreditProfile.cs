using System;
using Shared;

namespace AccountManagement {
  public class CreditProfile {
    public Guid Id { get; set; }
    public AccountHolder AccountHolder { get; set; }
  }

  public class AccountHolder : ReadOnlyEntity {
    public Guid ContactId { get; set; }
  }
}