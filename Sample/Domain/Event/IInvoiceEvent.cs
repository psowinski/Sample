using Sample.Model;

namespace Sample.Domain.Event
{
   public interface IInvoiceEvent
   {
      void Visit(IInvoice invoice);
   }
}