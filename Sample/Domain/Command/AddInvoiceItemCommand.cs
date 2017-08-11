using System;
using Sample.Model;

namespace Sample.Domain.Command
{
   public class AddInvoiceItemCommand
   {
      public InvoiceItem Item { get; }

      public AddInvoiceItemCommand(InvoiceItem item)
      {
         if (string.IsNullOrWhiteSpace(item.ProductId)
            || item.Price < 0m
            || item.Amount == 0)
            throw new ArgumentException(nameof(item));
         Item = item;
      }
   }
}
