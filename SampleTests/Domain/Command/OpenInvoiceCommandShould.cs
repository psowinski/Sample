using System;
using Sample.Domain.Command;
using Xunit;

namespace SampleTests.Domain.Command
{
   public class OpenInvoiceCommandShould
   {
      [Fact]
      public void NotAcceptEmptyCustomerId()
      {
         Assert.Throws<ArgumentException>(() => new OpenInvoiceCommand(null));
         Assert.Throws<ArgumentException>(() => new OpenInvoiceCommand(""));
         Assert.Throws<ArgumentException>(() => new OpenInvoiceCommand("   "));
      }

      [Fact]
      public void TrackPassedCustomerId()
      {
         var customerId = "123";
         var customer = new OpenInvoiceCommand(customerId);
         Assert.Equal(customerId, customer.CustomerId);
      }
   }
}
