using System;
using System.Reactive.Linq;
using Moq;
using Sample.Domain;
using Sample.Domain.Command;
using Sample.Domain.Event;
using Sample.Model;
using Xunit;

namespace SampleTests.Domain
{
   public class InvoiceRootShould
   {
      private readonly InvoiceRoot invoiceRoot = new InvoiceRoot();

      [Fact]
      public void AllowToCreateZeroStateInvoice()
      {
         Assert.IsAssignableFrom<IInvoice>(this.invoiceRoot.CreateZeroState());
      }

      [Fact]
      public void AllowToOpenAnInvoice()
      {
         var customerId = "123";
         var openCommand = new OpenInvoiceCommand(customerId);

         InvoiceOpenEvent @event = null;
         using (this.invoiceRoot
            .Where(x => x is InvoiceOpenEvent)
            .Select(x => x as InvoiceOpenEvent)
            .Subscribe(x => @event = x))
         {
            this.invoiceRoot.ExecuteCommand(new Mock<IInvoice>().Object, openCommand);
            Assert.Equal(customerId, @event.CustomerId);
         }
      }
   }
}
