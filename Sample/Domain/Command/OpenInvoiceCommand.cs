using System;

namespace Sample.Domain.Command
{
   public class OpenInvoiceCommand
   {
      public string CustomerId { get; }

      public OpenInvoiceCommand(string customerId)
      {
         if (string.IsNullOrWhiteSpace(customerId))
            throw new ArgumentException(nameof(customerId));
         CustomerId = customerId;
      }
   }
}
