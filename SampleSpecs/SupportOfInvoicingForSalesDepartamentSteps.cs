using System;
using Sample.Domain;
using Sample.Domain.Command;
using Sample.Model;
using TechTalk.SpecFlow;
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
            this.invoiceRoot.Execute(this.invoice, new AddInvoiceItemCommand(new InvoiceItem("1", 1m, 1u)));
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
   }
}
