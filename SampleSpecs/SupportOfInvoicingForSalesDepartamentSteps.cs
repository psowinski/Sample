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
    }
}
