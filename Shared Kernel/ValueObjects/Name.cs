namespace Shared.ValueObjects {
  //no ID because it's a value object
  //EF will recognize this as a complex type
  //parts of this class borrowed from Vaughn Vernon IDDD.NET sample
  public class Name : ValueObject<Name> {
    public Name(string firstName, string lastName) {
      FirstName = firstName;
      LastName = lastName;
    }

    public Name(Name fullName)
      : this(fullName.FirstName, fullName.LastName) {
    }

    protected Name() {
    }


    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string AsFormattedName() {
      return FirstName + " " + LastName;
    }

    public Name WithChangedFirstName(string firstName) {
      return new Name(firstName, LastName);
    }

    public Name WithChangedLastName(string lastName) {
      return new Name(FirstName, lastName);
    }

    public override string ToString() {
      return "Name [firstName=" + FirstName + ", lastName=" + LastName + "]";
    }
  }
}