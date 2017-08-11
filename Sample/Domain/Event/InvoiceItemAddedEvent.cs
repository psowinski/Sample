using Sample.Model;

namespace Sample.Domain.Event
{
   public class InvoiceItemAddedEvent : IInvoiceEvent
   {
      public InvoiceItem Item { get; }

      public InvoiceItemAddedEvent(InvoiceItem item)
      {
         Item = item;
      }

      public void Visit(IInvoice invoice)
      {
         invoice.Apply(this);
      }
   }
}
