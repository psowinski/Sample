using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

      public decimal TotalSum => this.items.Aggregate(0m, (sum, item) => sum + item.Price * item.Amount);

      public void Handle(InvoiceItemAddedEvent @event)
      {
         this.items.Add(@event.Item);
      }
   }
}
