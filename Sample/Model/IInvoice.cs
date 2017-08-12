using System.Collections.ObjectModel;
using Sample.Domain.Event;

namespace Sample.Model
{
   public interface IInvoice : IEventHandler<InvoiceOpenedEvent>,
                               IEventHandler<InvoiceItemAddedEvent>
   {
      bool IsBlank { get; }
      bool IsOpen { get; }
      string CustomerId { get; }
      ReadOnlyCollection<InvoiceItem> Items { get; }
      decimal TotalSum { get; }
   }
}