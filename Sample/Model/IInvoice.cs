using Sample.Domain.Event;

namespace Sample.Model
{
   public interface IInvoice
   {
      bool IsBlank { get; }
      bool IsOpen { get; }
      string CustomerId { get; }

      void Apply(IInvoiceEvent @event);

      void Apply(InvoiceOpenedEvent @event);
   }
}