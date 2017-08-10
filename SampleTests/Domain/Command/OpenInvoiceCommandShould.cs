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
   }
}
