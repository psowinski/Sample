using Sample.Model;

namespace Sample.Domain
{
   public class InvoiceRoot
   {
      public IInvoice CreateZeroState()
      {
         return new Invoice();
      }
   }
}
