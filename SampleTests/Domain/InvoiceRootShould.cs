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
         Assert.IsAssignableFrom<IInvoice>(this.invoiceRoot.Zero());
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

            this.invoiceRoot.Execute(this.invoice.Object, openCommand);
            Assert.Equal(customerId, invoiceEvent.CustomerId);
         }
      }

      [Fact]
      public void CreateZeroStateInvoice()
      {
         var zeroState = this.invoiceRoot.Zero();
         Assert.True(zeroState.IsBlank);
         Assert.False(zeroState.IsOpen);
      }

      [Fact]
      public void NotAllowToOpenAnInvoiceIfItIsNotBlank()
      {
         Assert.Throws<InvalidOperationException>(
            () => this.invoiceRoot.Execute(this.invoice.Object, new OpenInvoiceCommand("123")));
      }

      [Fact]
      public void NotAllowToAddItemToUnopenInvoice()
      {
         var addItemCommand = new AddInvoiceItemCommand(new InvoiceItem("1", 2m, 2));
         Assert.Throws<InvalidOperationException>(
            () => this.invoiceRoot.Execute(this.invoice.Object, addItemCommand));
      }

      [Fact]
      public void AllowToAddItemToOpenInvoice()
      {
         var item = new InvoiceItem("1", 1m, 1u);
         var addItemCommand = new AddInvoiceItemCommand(item);

         InvoiceItemAddedEvent invoiceEvent = null;
         using (this.invoiceRoot
            .Where(x => x is InvoiceItemAddedEvent)
            .Select(x => x as InvoiceItemAddedEvent)
            .Subscribe(x => invoiceEvent = x))
         {
            this.invoice.SetupGet(x => x.IsOpen).Returns(true);

            this.invoiceRoot.Execute(this.invoice.Object, addItemCommand);
            Assert.Equal(item, invoiceEvent.Item);
         }
      }

      [Fact]
      public void VisitEventDuringApply()
      {
         var @event = new Mock<IEvent<IInvoice>>();
         this.invoiceRoot.Apply(this.invoice.Object, @event.Object);
         @event.Verify(x => x.Visit(this.invoice.Object), Times.Once);
      }

      [Fact]
      public void VisitCommandDuringExecution()
      {
         var command = new Mock<ICommand<IInvoice, IInvoiceRoot>>();
         this.invoiceRoot.Execute(this.invoice.Object, command.Object);
         command.Verify(x => x.Visit(this.invoiceRoot, this.invoice.Object), Times.Once);
      }

      [Fact]
      public void AllowToSetInvoiceSellDate()
      {
         var date = DateTime.Now;
         var command = new SetInvoiceSellDateCommand(date);

         InvoiceSellDateSetEvent invoiceEvent = null;
         using (this.invoiceRoot
            .Where(x => x is InvoiceSellDateSetEvent)
            .Select(x => x as InvoiceSellDateSetEvent)
            .Subscribe(x => invoiceEvent = x))
         {
            this.invoice.SetupGet(x => x.IsOpen).Returns(true);

            this.invoiceRoot.Execute(this.invoice.Object, command);
            Assert.Equal(date, invoiceEvent.Date);
         }
      }
   }
}
