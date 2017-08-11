using System;
using Sample.Domain.Command;
using Sample.Model;
using Xunit;

namespace SampleTests.Domain.Command
{
   class AddInvoiceItemCommandShould
   {
      public void NotAcceptEmptyProductId()
      {
         Assert.Throws<ArgumentException>(() => new AddInvoiceItemCommand(new InvoiceItem(null, 1.50m, 1)));
         Assert.Throws<ArgumentException>(() => new AddInvoiceItemCommand(new InvoiceItem("", 1.50m, 1)));
         Assert.Throws<ArgumentException>(() => new AddInvoiceItemCommand(new InvoiceItem("   ", 1.50m, 1)));
      }

      public void NotAcceptNegativePrice()
      {
         Assert.Throws<ArgumentException>(() => new AddInvoiceItemCommand(new InvoiceItem("1", -1.50m, 1)));
      }

      public void NotAcceptZeroAmount()
      {
         Assert.Throws<ArgumentException>(() => new AddInvoiceItemCommand(new InvoiceItem("1", 1.50m, 0)));
      }
   }
}
