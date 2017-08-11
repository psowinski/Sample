using System;
using Sample.Model;

namespace Sample.Domain.Command
{
   public class AddInvoiceItemCommand : ICommand<IInvoice, IInvoiceRoot>
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

      public void Visit(IInvoiceRoot visitor, IInvoice state) => visitor.Handle(state, this);
   }
}
