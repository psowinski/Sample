using Sample.Model;

namespace Sample.Domain.Event
{
   public class InvoiceItemAddedEvent : IEvent<IInvoice>
   {
      public InvoiceItem Item { get; }

      public InvoiceItemAddedEvent(InvoiceItem item)
      {
         Item = item;
      }

      public void Visit(IInvoice invoice)
      {
         invoice.Handle(this);
      }
   }
}
