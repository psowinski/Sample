using System;
using Sample.Model;

namespace Sample.Domain.Command
{
   public class OpenInvoiceCommand : ICommand<IInvoice, IInvoiceRoot>
   {
      public string CustomerId { get; }

      public OpenInvoiceCommand(string customerId)
      {
         if (string.IsNullOrWhiteSpace(customerId))
            throw new ArgumentException(nameof(customerId));
         CustomerId = customerId;
      }

      public void Visit(IInvoiceRoot visitor, IInvoice state) => visitor.Handle(state, this);
   }
}
