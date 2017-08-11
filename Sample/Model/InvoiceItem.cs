using System;

namespace Sample.Model
{
   public class InvoiceItem
   {
      public string ProductId { get; }
      public decimal Price { get; }
      public uint Amount { get; }

      public InvoiceItem(string productId, decimal price, uint amount)
      {
         ProductId = productId;
         Price = price;
         Amount = amount;
      }
   }
}