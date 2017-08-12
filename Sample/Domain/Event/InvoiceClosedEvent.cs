using Sample.Model;

namespace Sample.Domain.Event
{
   public class InvoiceClosedEvent : IEvent<IInvoice>
   {
      public void Visit(IInvoice invoice) => invoice.Handle(this);
   }
}