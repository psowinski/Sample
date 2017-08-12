using System;
using System.Linq;
using Moq;
using Sample.Domain;
using Sample.Domain.Command;
using Sample.Model;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace SampleSpecs
{
   [Binding]
   public class SupportOfInvoicingForSalesDepartamentSteps
   {
      private readonly InvoiceRoot invoiceRoot = new InvoiceRoot();
      private IInvoice invoice;
      private string customerId = "123";
      private string errorMsg;

      [Given(@"is an empty unopened invoice")]
      public void GivenIsAnEmptyUnopenedInvoice()
      {
         this.invoice = this.invoiceRoot.Zero();
      }

      [When(@"I try to add item to it")]
      public void WhenITryToAddItemToIt()
      {
         try
         {
            this.invoiceRoot.Execute(this.invoice, 
               new AddInvoiceItemCommand(new InvoiceItem("1", 1m, 1u)));
         }
         catch (InvalidOperationException ex)
         {
            this.errorMsg = ex.ToString();
         }
      }

      [Then(@"I should get an error ""(.*)""")]
      public void ThenIShouldGetAnError(string error)
      {
         Assert.Contains(error, this.errorMsg);
      }

      [When(@"I open it for some customer")]
      public void WhenIOpenItForSomeCustomer()
      {
         using (this.invoiceRoot.Subscribe(e => this.invoiceRoot.Apply(this.invoice, e)))
            this.invoiceRoot.Execute(this.invoice, new OpenInvoiceCommand(this.customerId));
      }

      [Then(@"it will report an owner")]
      public void ThenItWillReportAnOwner()
      {
         Assert.Equal(this.customerId, this.invoice.CustomerId);
      }

      [Then(@"open state")]
      public void ThenOpenState()
      {
         Assert.True(this.invoice.IsOpen);
      }

      [Given(@"is an open invoice")]
      [Given(@"is an open invoice without items")]
      public void GivenIsAnOpenInvoice()
      {
         GivenIsAnEmptyUnopenedInvoice();
         WhenIOpenItForSomeCustomer();
      }

      [When(@"I add an item:")]
      [When(@"I add a few items:")]
      [When(@"I add twice the same item:")]
      [Given(@"it contians item")]
      public void AddItems(Table table)
      {
         try
         {
            var items = table.CreateSet<InvoiceItemRow>();
            using (this.invoiceRoot.Subscribe(e => this.invoiceRoot.Apply(this.invoice, e)))
            {
               foreach (var item in items)
                  this.invoiceRoot.Execute(this.invoice,
                     new AddInvoiceItemCommand(item.ToInvoiceItem()));
            }
         }
         catch (Exception ex)
         {
            this.errorMsg = ex.ToString();
         }
      }

      [Then(@"total sum should be equal to (.*)")]
      public void ThenTotalSumShouldBeEqualTo(decimal totalSum)
      {
         Assert.Equal(totalSum, this.invoice.TotalSum);
      }

      [Then(@"it should contian item:")]
      public void ThenItShouldContianItem(Table table)
      {
         var item = table.CreateInstance<InvoiceItemRow>();
         Assert.True(this.invoice.Items.All(x => x == item.ToInvoiceItem()));
      }

      [When(@"I set a sale date '(.*)'")]
      [Given(@"it has set a date '(.*)'")]
      public void WhenISetASaleDate(DateTime date)
      {
         try
         {
            using (this.invoiceRoot.Subscribe(e => this.invoiceRoot.Apply(this.invoice, e)))
               this.invoiceRoot.Execute(this.invoice, new SetInvoiceSellDateCommand(date));
         }
         catch (InvalidOperationException ex)
         {
            this.errorMsg = ex.ToString();
         }
      }

      [Then(@"an invoice should present the last one '(.*)'")]
      public void ThenAnInvoiceShouldPresentTheLastOne(DateTime date)
      {
         Assert.Equal(date, this.invoice.Date);
      }

      [When(@"I close it")]
      public void WhenICloseIt()
      {
         try
         {
            using (this.invoiceRoot.Subscribe(e => this.invoiceRoot.Apply(this.invoice, e)))
               this.invoiceRoot.Execute(this.invoice, new CloseInvoiceCommand());
         }
         catch (InvalidOperationException ex)
         {
            this.errorMsg = ex.ToString();
         }
      }

      [Then(@"it should report as closed not blank")]
      public void ThenItShouldReportAsClosed()
      {
         Assert.False(this.invoice.IsOpen);
         Assert.False(this.invoice.IsBlank);
      }

      [Given(@"is a closed invoice")]
      public void GivenIsAClosedInvoice()
      {
         this.invoice = new Mock<IInvoice>().Object;
      }
   }
}
