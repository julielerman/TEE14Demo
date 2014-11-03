namespace Shared.ValueObjects {
  //value object
  //no id
  //immutable
  //equality check
  public class Address : ValueObject<Address> {
    private Address(string street1, string street2, string city, string region, string country, string postalCode) {
      Street1 = street1;
      Street2 = street2;
      City = city;
      Region = region;
      Country = country;
      PostalCode = postalCode;
    }

    internal Address() {
    }

    public string Street1 { get; private set; }
    public string Street2 { get; private set; }
    public string City { get; private set; }
    public string Region { get; private set; }
    public string Country { get; private set; }
    public string PostalCode { get; private set; }

    public static Address CreateAddress(string street1, string street2, string city, string region, string country,
      string postalCode) {
      return new Address(street1, street2, city, region, country, postalCode);
    }

    public static Address DefaultAddress() {
      return new Address("", "", "", "", "", "");
    }

    //mre
  }
}