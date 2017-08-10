namespace Sample.Domain.Event
{
   public class InvoiceOpenEvent : IEvent
   {
      public string CustomerId { get; }

      public InvoiceOpenEvent(string customerId)
      {
         CustomerId = customerId;
      }
   }
}
