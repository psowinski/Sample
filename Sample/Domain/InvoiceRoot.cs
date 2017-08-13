using System;
using Sample.Domain.Command;
using Sample.Domain.Event;
using Sample.Model;

namespace Sample.Domain
{
   public class InvoiceRoot : AggregateRoot<IInvoice, IInvoiceRoot>, IInvoiceRoot
   {
      public override IInvoice Zero() => new Invoice();

      public override void Execute(IInvoice state, ICommand<IInvoice, IInvoiceRoot> command) => command.Visit(this, state);

      public void Handle(IInvoice invoice, OpenInvoiceCommand command)
      {
         if(!invoice.IsBlank) RiseError(new InvalidOperationException("Only blank invoice can be opened."));
         Publish(new InvoiceOpenedEvent(command.CustomerId));
      }

      public void Handle(IInvoice state, AddInvoiceItemCommand command)
      {
         RequireOpenInvoice(state);
         Publish(new InvoiceItemAddedEvent(command.Item));
      }

      public void Handle(IInvoice state, SetInvoiceSellDateCommand command)
      {
         RequireOpenInvoice(state);
         Publish(new InvoiceSellDateSetEvent(command.Date));
      }

      public void Handle(IInvoice state, CloseInvoiceCommand command)
      {
         if(state.Items == null || state.Items.Count == 0)
            RiseError(new InvalidOperationException("Cannot close an empty invoice."));
         if (state.Date == default(DateTime))
            RiseError(new InvalidOperationException("Cannot close invoice without sell date."));
         Publish(new InvoiceClosedEvent());
      }

      private void RequireOpenInvoice(IInvoice invoice)
      {
         if (!invoice.IsOpen)
            RiseError(new InvalidOperationException(
               invoice.IsBlank
               ? "You need to open invoice befor modification."
               : "Cannot modify closed invoice."));
      }
   }
}
