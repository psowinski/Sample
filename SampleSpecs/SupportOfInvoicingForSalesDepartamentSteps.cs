using Sample.Domain;
using Sample.Domain.Command;
using Sample.Model;
using TechTalk.SpecFlow;

namespace SampleSpecs
{
   [Binding]
   public class SupportOfInvoicingForSalesDepartamentSteps
   {
      private readonly InvoiceRoot invoiceRoot = new InvoiceRoot();
      private IInvoice invoice;

      [Given(@"is an empty unopened invoice")]
      public void GivenIsAnEmptyUnopenedInvoice()
      {
         this.invoice = this.invoiceRoot.CreateZeroState();
      }

      [When(@"I try to add item to it")]
      public void WhenITryToAddItemToIt()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"I should get an error ""(.*)""")]
      public void ThenIShouldGetAnError(string error)
      {
         ScenarioContext.Current.Pending();
      }

      [When(@"I open it for some customer")]
      public void WhenIOpenItForSomeCustomer()
      {
         //this.invoiceRoot.Subscribe(this.invoice.Apply);
         this.invoiceRoot.ExecuteCommand(this.invoice, new OpenInvoiceCommand("123"));
      }

      [Then(@"it will report an owner")]
      public void ThenItWillReportAnOwner()
      {
         ScenarioContext.Current.Pending();
      }

      [Then(@"open state")]
      public void ThenOpenState()
      {
         ScenarioContext.Current.Pending();
      }
   }
}
