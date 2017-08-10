using Sample.Domain.Event;
using Sample.Model;
using Xunit;

namespace SampleTests.Model
{
   public class InvoiceShould
   {
      private readonly Invoice invoice = new Invoice();

      
      [Fact]
      public void ApplyInvoiceOpenedEvent()
      {
         var customerId = "123";
         this.invoice.Apply(new InvoiceOpenedEvent(customerId));
         Assert.Equal(customerId, this.invoice.CustomerId);
      }
   }
}
