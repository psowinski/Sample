using System;
using Sample.Domain.Command;
using Sample.Domain.Event;
using Sample.Model;

namespace Sample.Domain
{
   public class InvoiceRoot : AggregateRoot<IInvoice, IInvoiceEvent>
   {
      public override IInvoice CreateZeroState()
      {
         return new Invoice();
      }

      public override void ApplyEvent(IInvoice state, IInvoiceEvent @event)
      {
         @event.Visit(state);
      }

      public void ExecuteCommand(IInvoice invoice, OpenInvoiceCommand command)
      {
         if(!invoice.IsBlank) throw new InvalidOperationException("Only blank invoice can be opened.");
         Publish(new InvoiceOpenedEvent(command.CustomerId));
      }

      public void ExecuteCommand(IInvoice invoice, AddInvoiceItemCommand command)
      {
         if (!invoice.IsOpen) throw new InvalidOperationException("You need to open invoice befor modification.");
         Publish(new InvoiceItemAddedEvent(command.Item));
      }
   }
}
