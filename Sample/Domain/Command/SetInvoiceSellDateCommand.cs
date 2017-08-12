using System;
using Sample.Model;

namespace Sample.Domain.Command
{
   public class SetInvoiceSellDateCommand : ICommand<IInvoice, IInvoiceRoot>
   {
      public DateTime Date { get; }

      public SetInvoiceSellDateCommand(DateTime date)
      {
         Date = date;
      }

      public void Visit(IInvoiceRoot visitor, IInvoice state) => visitor.Handle(state, this);
   }
}