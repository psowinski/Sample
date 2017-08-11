using System;
using Sample.Domain.Command;
using Xunit;

namespace SampleTests.Domain.Command
{
   class AddInvoiceItemCommandShould
   {
      public void NotAcceptEmptyProductId()
      {
         Assert.Throws<ArgumentException>(() => new AddInvoiceItemCommand(null, 1.50m, 1));
         Assert.Throws<ArgumentException>(() => new AddInvoiceItemCommand("", 1.50m, 1));
         Assert.Throws<ArgumentException>(() => new AddInvoiceItemCommand("   ", 1.50m, 1));
      }

      public void NotAcceptNegativePrice()
      {
         Assert.Throws<ArgumentException>(() => new AddInvoiceItemCommand("1", -1.50m, 1));
      }

      public void NotAcceptZeroAmount()
      {
         Assert.Throws<ArgumentException>(() => new AddInvoiceItemCommand("1", 1.50m, 0));
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
