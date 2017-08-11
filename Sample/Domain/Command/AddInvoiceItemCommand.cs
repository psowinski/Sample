using System;

namespace Sample.Domain.Command
{
   public class AddInvoiceItemCommand
   {
      public string ProductId { get; }
      public decimal Price { get; }
      public uint Amount { get; }

      public AddInvoiceItemCommand(string productId, decimal price, uint amount)
      {
         if (string.IsNullOrWhiteSpace(productId))
            throw new ArgumentException(nameof(productId));
         if (price < 0)
            throw new ArgumentException(nameof(price));
         if (amount == 0)
            throw new ArgumentException(nameof(amount));

         ProductId = productId;
         Price = price;
         Amount = amount;
      }
   }
}
