namespace SalesDomain {
  public class CustomerCreditCard {
    public CustomerCreditCard(string cardNumber, string bank) {
      Number = cardNumber;
      Bank = bank;
    }

    public int Id { get; set; }
    public string Number { get; set; }
    public string Bank { get; set; }
  }
}