using Sample.Domain.Command;
using Sample.Model;

namespace Sample.Domain
{
   public interface IInvoiceRoot:
      ICommandHandler<IInvoice, OpenInvoiceCommand>,
      ICommandHandler<IInvoice, AddInvoiceItemCommand>,
      ICommandHandler<IInvoice, SetInvoiceSellDateCommand>
   {
   }
}