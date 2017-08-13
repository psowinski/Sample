using System;
using Sample.Domain.Command;
using Sample.Model;
using Xunit;

namespace SampleTests.Domain.Command
{
   public class AddInvoiceItemCommandShould
   {
      [Fact]
      public void NotAcceptEmptyProductId()
      {
         Assert.Throws<ArgumentException>(() => new AddInvoiceItemCommand(new InvoiceItem(null, 1.50m, 1)));
         Assert.Throws<ArgumentException>(() => new AddInvoiceItemCommand(new InvoiceItem("", 1.50m, 1)));
         Assert.Throws<ArgumentException>(() => new AddInvoiceItemCommand(new InvoiceItem("   ", 1.50m, 1)));
      }

      [Fact]
      public void NotAcceptNegativePrice()
      {
         Assert.Throws<ArgumentException>(() => new AddInvoiceItemCommand(new InvoiceItem("1", -1.50m, 1)));
      }

      [Fact]
      public void NotAcceptZeroAmount()
      {
         Assert.Throws<ArgumentException>(() => new AddInvoiceItemCommand(new InvoiceItem("1", 1.50m, 0)));
      }
   }
}
