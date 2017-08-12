using System;
using Sample.Model;

namespace Sample.Domain.Event
{
   public class InvoiceSellDateSetEvent : IEvent<IInvoice>
   {
      public DateTime Date { get; }

      public InvoiceSellDateSetEvent(DateTime date)
      {
         Date = date;
      }

      public void Visit(IInvoice invoice) => invoice.Handle(this);
   }
}