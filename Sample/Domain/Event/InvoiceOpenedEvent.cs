namespace Sample.Domain.Event
{
   public class InvoiceOpenedEvent : IEvent
   {
      public string CustomerId { get; }

      public InvoiceOpenedEvent(string customerId)
      {
         CustomerId = customerId;
      }
   }
}
