using Sample.Model;

namespace Sample.Domain.Command
{
   public class CloseInvoiceCommand : ICommand<IInvoice, IInvoiceRoot>
   {
      public void Visit(IInvoiceRoot visitor, IInvoice state) => visitor.Handle(state, this);
   }
}