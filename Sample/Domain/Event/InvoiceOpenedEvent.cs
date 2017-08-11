using Sample.Model;

namespace Sample.Domain.Event
{
   public class InvoiceOpenedEvent : IInvoiceEvent
   {
      public string CustomerId { get; }

      public InvoiceOpenedEvent(string customerId)
      {
         CustomerId = customerId;
      }

      public void Visit(IInvoice invoice)
      {
         invoice.Handle(this);
      }
   }
}
