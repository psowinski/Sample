﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SampleSpecs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class SupportOfInvoicingForSalesDepartamentFeature : Xunit.IClassFixture<SupportOfInvoicingForSalesDepartamentFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Invoice.feature"
#line hidden
        
        public SupportOfInvoicingForSalesDepartamentFeature(SupportOfInvoicingForSalesDepartamentFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Support of invoicing for sales departament", @"   As a seller I want to be able to create an invoice to put ordered items on it
   As a seller I want to be able to put items on invoice to calculate total sum
   As a seller I want to be able to change invoice date to specify sale date
   As a seller I want to be able to close invoice so it cannot be changed", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Opening invoice")]
        [Xunit.TraitAttribute("FeatureTitle", "Support of invoicing for sales departament")]
        [Xunit.TraitAttribute("Description", "Opening invoice")]
        public virtual void OpeningInvoice()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Opening invoice", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
   testRunner.Given("is an empty unopened invoice", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
   testRunner.When("I open it for some customer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
   testRunner.Then("it will report an owner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
   testRunner.And("open state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Unopened invoice modification")]
        [Xunit.TraitAttribute("FeatureTitle", "Support of invoicing for sales departament")]
        [Xunit.TraitAttribute("Description", "Unopened invoice modification")]
        public virtual void UnopenedInvoiceModification()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unopened invoice modification", ((string[])(null)));
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
   testRunner.Given("is an empty unopened invoice", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
   testRunner.When("I try to add item to it", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
   testRunner.Then("I should get an error \"You need to open invoice befor modification.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Calculate total sum")]
        [Xunit.TraitAttribute("FeatureTitle", "Support of invoicing for sales departament")]
        [Xunit.TraitAttribute("Description", "Calculate total sum")]
        public virtual void CalculateTotalSum()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calculate total sum", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
   testRunner.Given("is an open invoice", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "ProductId",
                        "Price",
                        "Amount"});
            table1.AddRow(new string[] {
                        "1",
                        "5.00",
                        "3"});
            table1.AddRow(new string[] {
                        "2",
                        "3.50",
                        "1"});
            table1.AddRow(new string[] {
                        "3",
                        "1.50",
                        "2"});
#line 20
   testRunner.When("I add a few items:", ((string)(null)), table1, "When ");
#line 25
   testRunner.Then("total sum should be equal to 21.50", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Sum amount of the same items")]
        [Xunit.TraitAttribute("FeatureTitle", "Support of invoicing for sales departament")]
        [Xunit.TraitAttribute("Description", "Sum amount of the same items")]
        public virtual void SumAmountOfTheSameItems()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sum amount of the same items", ((string[])(null)));
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
   testRunner.Given("is an open invoice", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "ProductId",
                        "Price",
                        "Amount"});
            table2.AddRow(new string[] {
                        "1",
                        "5.00",
                        "3"});
            table2.AddRow(new string[] {
                        "1",
                        "5.00",
                        "4"});
#line 29
   testRunner.When("I add twice the same item:", ((string)(null)), table2, "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "ProductId",
                        "Price",
                        "Amount"});
            table3.AddRow(new string[] {
                        "1",
                        "5.00",
                        "7"});
#line 33
   testRunner.Then("it should contian item:", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Set invoice sale date")]
        [Xunit.TraitAttribute("FeatureTitle", "Support of invoicing for sales departament")]
        [Xunit.TraitAttribute("Description", "Set invoice sale date")]
        public virtual void SetInvoiceSaleDate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Set invoice sale date", ((string[])(null)));
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
   testRunner.Given("is an open invoice", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
   testRunner.When("I set a sale date \'2017-07-07\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
   testRunner.And("I set a sale date \'2017-08-08\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
   testRunner.Then("an invoice should present the last one \'2017-08-08\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Cannot set a sale date on unopen invoice")]
        [Xunit.TraitAttribute("FeatureTitle", "Support of invoicing for sales departament")]
        [Xunit.TraitAttribute("Description", "Cannot set a sale date on unopen invoice")]
        public virtual void CannotSetASaleDateOnUnopenInvoice()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cannot set a sale date on unopen invoice", ((string[])(null)));
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
   testRunner.Given("is an empty unopened invoice", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
   testRunner.When("I set a sale date \'2017-07-07\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
   testRunner.Then("I should get an error \"You need to open invoice befor modification.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Close valid invoice")]
        [Xunit.TraitAttribute("FeatureTitle", "Support of invoicing for sales departament")]
        [Xunit.TraitAttribute("Description", "Close valid invoice")]
        public virtual void CloseValidInvoice()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Close valid invoice", ((string[])(null)));
#line 48
this.ScenarioSetup(scenarioInfo);
#line 49
   testRunner.Given("is an open invoice", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "ProductId",
                        "Price",
                        "Amount"});
            table4.AddRow(new string[] {
                        "1",
                        "1.00",
                        "1"});
#line 50
   testRunner.And("it contians item", ((string)(null)), table4, "And ");
#line 53
   testRunner.And("it has set a date \'2017-07-07\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
   testRunner.When("I close it", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
   testRunner.Then("it should report as closed not blank", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Close an empty invoice")]
        [Xunit.TraitAttribute("FeatureTitle", "Support of invoicing for sales departament")]
        [Xunit.TraitAttribute("Description", "Close an empty invoice")]
        public virtual void CloseAnEmptyInvoice()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Close an empty invoice", ((string[])(null)));
#line 57
this.ScenarioSetup(scenarioInfo);
#line 58
   testRunner.Given("is an open invoice without items", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 59
   testRunner.When("I close it", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
   testRunner.Then("I should get an error \"Cannot close an empty invoice.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                SupportOfInvoicingForSalesDepartamentFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                SupportOfInvoicingForSalesDepartamentFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
