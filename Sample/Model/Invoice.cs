using System.Collections.Generic;
using Sample.Domain.Event;

namespace Sample.Model
{
   public class Invoice : IInvoice
   {
      public bool IsBlank => CustomerId == null;

      public string CustomerId { get; private set; }

      public void Apply(InvoiceOpenedEvent @event)
      {
         CustomerId = @event.CustomerId;
      }
   }
}