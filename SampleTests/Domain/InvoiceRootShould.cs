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
      private readonly Mock<IInvoice> invoice = new Mock<IInvoice>();

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

         InvoiceOpenedEvent invoiceEvent = null;
         using (this.invoiceRoot
            .Where(x => x is InvoiceOpenedEvent)
            .Select(x => x as InvoiceOpenedEvent)
            .Subscribe(x => invoiceEvent = x))
         {
            this.invoice.SetupGet(x => x.IsBlank).Returns(true);

            this.invoiceRoot.ExecuteCommand(this.invoice.Object, openCommand);
            Assert.Equal(customerId, invoiceEvent.CustomerId);
         }
      }

      [Fact]
      public void CreateZeroStateInvoice()
      {
         var zeroState = this.invoiceRoot.CreateZeroState();
         Assert.True(zeroState.IsBlank);
         Assert.False(zeroState.IsOpen);
      }

      [Fact]
      public void NotAllowToOpenAnInvoiceIfItIsNotBlank()
      {
         Assert.Throws<InvalidOperationException>(
            () => this.invoiceRoot.ExecuteCommand(this.invoice.Object, new OpenInvoiceCommand("123")));
      }

      [Fact]
      public void AllowToAddItem()
      {
         var addItemCommand = new AddInvoiceItemCommand("1", 2m, 2);

         //InvoiceOpenedEvent invoiceEvent = null;
         //using (this.invoiceRoot
         //   .Where(x => x is InvoiceOpenedEvent)
         //   .Select(x => x as InvoiceOpenedEvent)
         //   .Subscribe(x => invoiceEvent = x))
         //{
         //   this.invoice.SetupGet(x => x.IsBlank).Returns(true);

         //   this.invoiceRoot.ExecuteCommand(this.invoice.Object, openCommand);
         //   Assert.Equal(customerId, invoiceEvent.CustomerId);
         //}
      }
   }
}
