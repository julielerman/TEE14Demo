using Shared;

namespace ContactManagement.Core.Model
{
  //value object
  //no id
  //immutable
  //equality check
  public class Address : ValueObject<Address>
  {
    public Address(string street1, string street2, string city, string region, string country, string postalCode)
    {
      Street1 = street1;
      Street2 = street2;
      City = city;
      Region = region;
      Country = country;
      PostalCode = postalCode;
    }

    internal Address()
    {
    }

    public string Street1 { get; private set; }
    public string Street2 { get; private set; }
    public string City { get; private set; }
    public string Region { get; private set; }
    public string Country { get; private set; }
    public string PostalCode { get; private set; }

    //mre
  }
}