using System;
using Sample.Domain.Command;
using Sample.Domain.Event;
using Sample.Model;

namespace Sample.Domain
{
   public class InvoiceRoot : AggregateRoot<IInvoice, IEvent>
   {
      public override IInvoice CreateZeroState()
      {
         return new Invoice();
      }

      public void ExecuteCommand(IInvoice invoice, OpenInvoiceCommand openCommand)
      {
         if(!invoice.IsBlank) throw new InvalidOperationException("Only blank invoice can be opened.");
         Publish(new InvoiceOpenedEvent(openCommand.CustomerId));
      }
   }
}
