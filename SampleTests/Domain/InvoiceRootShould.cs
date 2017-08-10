using Sample.Domain;
using Sample.Domain.Command;
using Sample.Model;
using Xunit;

namespace SampleTests.Domain
{
   public class InvoiceRootShould
   {
      [Fact]
      public void AllowToCreateZeroStateInvoice()
      {
         var invoiceRoot = new InvoiceRoot();
         Assert.IsAssignableFrom<IInvoice>(invoiceRoot.CreateZeroState());
      }

      [Fact]
      public void AllowToOpenAnInvoice()
      {
         var invoiceRoot = new InvoiceRoot();
         var openCommand = new OpenInvoiceCommand("CustormerId");
      }
   }
}
