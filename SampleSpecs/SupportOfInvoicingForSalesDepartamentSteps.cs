using TechTalk.SpecFlow;

namespace SampleSpecs
{
    [Binding]
    public class SupportOfInvoicingForSalesDepartamentSteps
    {
        [Given(@"is an empty unopened invoice")]
        public void GivenIsAnEmptyUnopenedInvoice()
        {
            ScenarioContext.Current.Pending();
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
          ScenarioContext.Current.Pending();
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
