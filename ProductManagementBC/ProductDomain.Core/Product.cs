using System;
using System.Collections.Generic;
using Shared.Enums;

namespace ProductManagement.Core
{
 
  public class Product
  {
    public static Product Create(string name, string productNumber) {
      return new Product(name, productNumber);
    }

    private Product(){}

    private Product(string name, string productNumber)
    {
      Name = name;
      ProductNumber = productNumber;
      SellStartDate = DateTime.Now;
     
  }

    public int Id { get; set; }
    public string Name { get; set; }
    public string ProductNumber { get; set; }
    public ProductColor Color { get; set; }
    public double StandardCost { get; set; }
    public double ListPrice { get; set; }
    public string Size { get; set; }
    public List<Category> Categories { get; set; }
    public DateTime SellStartDate { get; set; }

    public Nullable<double> ShippingWeight { get; set; }
    public Nullable<DateTime> SellEndDate { get; set; }
    public Nullable<DateTime> DiscontinuedDate { get; set; }

    public byte[] Photo { get; set; }
}
}