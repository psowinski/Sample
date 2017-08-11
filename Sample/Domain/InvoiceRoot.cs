using System;
using Sample.Domain.Command;
using Sample.Domain.Event;
using Sample.Model;

namespace Sample.Domain
{
   public class InvoiceRoot : AggregateRoot<IInvoice, IInvoiceRoot>, IInvoiceRoot
   {
      public override IInvoice CreateZeroState() => new Invoice();

      public override void ExecuteCommand(IInvoice state, ICommand<IInvoice, IInvoiceRoot> command) => command.Visit(this, state);

      public void Handle(IInvoice invoice, OpenInvoiceCommand command)
      {
         if(!invoice.IsBlank) throw new InvalidOperationException("Only blank invoice can be opened.");
         Publish(new InvoiceOpenedEvent(command.CustomerId));
      }

      public void Handle(IInvoice invoice, AddInvoiceItemCommand command)
      {
         if (!invoice.IsOpen) throw new InvalidOperationException("You need to open invoice befor modification.");
         Publish(new InvoiceItemAddedEvent(command.Item));
      }
   }
}
