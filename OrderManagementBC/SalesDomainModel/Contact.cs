using Shared;
using Shared.ValueObjects;

namespace SalesDomain {
  public class Contact : ReadOnlyEntity {
    private Contact() {
    }

    public Name Name { get; private set; }
  }
}