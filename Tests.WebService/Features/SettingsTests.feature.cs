// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.1.0.0
//      SpecFlow Generator Version:3.1.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Tests.WebService.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("SettingsTests")]
    public partial class SettingsTestsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "SettingsTests.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SettingsTests", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get Settings")]
        [NUnit.Framework.CategoryAttribute("CreateLocation")]
        [NUnit.Framework.CategoryAttribute("CreateLocations")]
        [NUnit.Framework.CategoryAttribute("LocationForAnotherOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateDepartment")]
        [NUnit.Framework.CategoryAttribute("CreateAnotherDepartmentSameLocation")]
        [NUnit.Framework.CategoryAttribute("CreateDepartmentAnotherLocationSameOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateDepartmentAnotherOrganisation")]
        public virtual void GetSettings()
        {
            string[] tagsOfScenario = new string[] {
                    "CreateLocation",
                    "CreateLocations",
                    "LocationForAnotherOrganisation",
                    "CreateDepartment",
                    "CreateAnotherDepartmentSameLocation",
                    "CreateDepartmentAnotherLocationSameOrganisation",
                    "CreateDepartmentAnotherOrganisation"};
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Settings", null, new string[] {
                        "CreateLocation",
                        "CreateLocations",
                        "LocationForAnotherOrganisation",
                        "CreateDepartment",
                        "CreateAnotherDepartmentSameLocation",
                        "CreateDepartmentAnotherLocationSameOrganisation",
                        "CreateDepartmentAnotherOrganisation"});
#line 13
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 14
    testRunner.Given("Daily peroods are created for departments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 15
 testRunner.Given("the /locations/{locationId}/departments/{departmentId}/Settings/ resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Value"});
                table2.AddRow(new string[] {
                            "locationId",
                            "$Location.ID"});
                table2.AddRow(new string[] {
                            "departmentId",
                            "$Department.ID"});
#line 16
  testRunner.And("the following url segments", ((string)(null)), table2, "And ");
#line hidden
#line 20
 testRunner.When("a GET request is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 21
 testRunner.Then("HTTP Code is 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 22
     testRunner.And("the response should be correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get Settings should return error when missing locationId or departmentId")]
        [NUnit.Framework.CategoryAttribute("CreateLocation")]
        [NUnit.Framework.CategoryAttribute("CreateLocations")]
        [NUnit.Framework.CategoryAttribute("LocationForAnotherOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateDepartment")]
        [NUnit.Framework.CategoryAttribute("CreateDepartmentAnotherLocationSameOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateDepartmentAnotherOrganisation")]
        [NUnit.Framework.TestCaseAttribute("1.MissingLocation", "", "$Department.ID", "404", null)]
        [NUnit.Framework.TestCaseAttribute("2.InvalidLocation", "123456", "$Department.ID", "401", null)]
        [NUnit.Framework.TestCaseAttribute("3.MissingDepartment", "$Location.ID", "", "404", null)]
        [NUnit.Framework.TestCaseAttribute("4.InvalidDepartment", "$Location.ID", "123456", "404", null)]
        [NUnit.Framework.TestCaseAttribute("5.DepartmentAnotherLocationSameOrganisation", "$Location.ID", "$DepartmentAnotherLocationSameOrganisation.ID", "401", null)]
        [NUnit.Framework.TestCaseAttribute("6.DepartmentAnotherOrganisation", "$Location.ID", "$DepartmentAnotherOrganisation.ID", "404", null)]
        [NUnit.Framework.TestCaseAttribute("7.DepartmentAnotherOrganisation", "$LocationAnotherOrganisation.ID", "$Department.ID", "401", null)]
        public virtual void GetSettingsShouldReturnErrorWhenMissingLocationIdOrDepartmentId(string testCase, string locationId, string departmentId, string code, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CreateLocation",
                    "CreateLocations",
                    "LocationForAnotherOrganisation",
                    "CreateDepartment",
                    "CreateDepartmentAnotherLocationSameOrganisation",
                    "CreateDepartmentAnotherOrganisation"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Settings should return error when missing locationId or departmentId", null, @__tags);
#line 31
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 32
 testRunner.Given("the /locations/{locationId}/departments/{departmentId}/shifts/{id}/ resource", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Value"});
                table3.AddRow(new string[] {
                            "locationId",
                            string.Format("{0}", locationId)});
                table3.AddRow(new string[] {
                            "departmentId",
                            string.Format("{0}", departmentId)});
#line 33
     testRunner.And("the following url segments", ((string)(null)), table3, "And ");
#line hidden
#line 37
 testRunner.When("a PUT request is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 38
 testRunner.Then(string.Format("HTTP Code is {0}", code), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
