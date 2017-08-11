using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Sample.Domain.Event;

namespace Sample.Model
{
   public class Invoice : IInvoice
   {
      public bool IsBlank => CustomerId == null;

      public bool IsOpen { get; private set; }

      public string CustomerId { get; private set; }

      public void Handle(InvoiceOpenedEvent @event)
      {
         CustomerId = @event.CustomerId;
         IsOpen = true;
      }

      private readonly List<InvoiceItem> items = new List<InvoiceItem>();

      public ReadOnlyCollection<InvoiceItem> Items => this.items.AsReadOnly();

      public void Handle(InvoiceItemAddedEvent @event)
      {
         this.items.Add(@event.Item);
      }
   }
}
