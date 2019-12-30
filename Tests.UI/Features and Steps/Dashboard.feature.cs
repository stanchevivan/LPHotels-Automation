// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Tests.UI.FeaturesAndSteps
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Dashboard")]
    public partial class DashboardFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Dashboard.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Dashboard", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        public virtual void ScenarioTearDown()
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
        [NUnit.Framework.DescriptionAttribute("Open create shift window")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("sandbox")]
        [NUnit.Framework.TestCaseAttribute("QA", new string[] {
                "QA"}, Category="QA")]
        [NUnit.Framework.TestCaseAttribute("local", new string[] {
                "local",
                "MockGet"}, Category="local,MockGet")]
        [NUnit.Framework.TestCaseAttribute("local", new string[] {
                "local"}, Category="local")]
        public virtual void OpenCreateShiftWindow(string environment, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "sandbox",
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Open create shift window", null, @__tags);
#line 4
    this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
     testRunner.Given(string.Format("LPH app is open on \"{0}\"", environment), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
     testRunner.When("shift window is open at \"5\" \"5\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 7
        testRunner.Then("shift popover is present", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create shift")]
        [NUnit.Framework.TestCaseAttribute("QA", "R1", "SS", "5:30", "7:30", new string[] {
                "QA"}, Category="QA")]
        public virtual void CreateShift(string environment, string role, string employee, string startTime, string endTime, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create shift", null, exampleTags);
#line 25
    this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 26
        testRunner.Given(string.Format("LPH app is open on \"{0}\"", environment), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
        testRunner.When(string.Format("new shift window is open for Role \"{0}\" Employee \"{1}\" for \"5:00\"", role, employee), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
            testRunner.And(string.Format("Shift details Start time is set to \"{0}\" and End Time is set to \"{1}\"", startTime, endTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line 29
            testRunner.And("Shift details Save button is clicked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line 30
        testRunner.Then(string.Format("Shift for Role \"{0}\" Employee \"{1}\" Start time \"{2}\" End time \"{3}\" is \"visible\"", role, employee, startTime, endTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Edit shift")]
        [NUnit.Framework.TestCaseAttribute("QA", "R1", "SS", "5:30", "7:30", "6:30", "8:30", new string[] {
                "local"}, Category="local")]
        public virtual void EditShift(string environment, string role, string employee, string oldStartTime, string oldEndTime, string newStartTime, string newEndTime, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit shift", null, exampleTags);
#line 37
    this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 38
        testRunner.Given(string.Format("LPH app is open on \"{0}\"", environment), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
        testRunner.When(string.Format("Shift details are opened for Role \"{0}\" Employee \"{1}\" Start time \"{2}\" End time " +
                        "\"{3}\"", role, employee, oldStartTime, oldEndTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
            testRunner.And(string.Format("Shift details Start time is set to \"{0}\" and End Time is set to \"{1}\"", newStartTime, newEndTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line 41
            testRunner.And("Shift details Save button is clicked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line 42
        testRunner.Then(string.Format("Shift for Role \"{0}\" Employee \"{1}\" Start time \"{2}\" End time \"{3}\" is \"visible\"", role, employee, newStartTime, newEndTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete shift")]
        [NUnit.Framework.TestCaseAttribute("QA", "R1", "SS", "6:30", "8:30", new string[] {
                "QA"}, Category="QA")]
        public virtual void DeleteShift(string environment, string role, string employee, string startTime, string endTime, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete shift", null, exampleTags);
#line 49
    this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 50
        testRunner.Given(string.Format("LPH app is open on \"{0}\"", environment), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
        testRunner.When(string.Format("Shift details are opened for Role \"{0}\" Employee \"{1}\" Start time \"{2}\" End time " +
                        "\"{3}\"", role, employee, startTime, endTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
            testRunner.And("Shift details Delete button is clicked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line 53
        testRunner.Then(string.Format("Shift for Role \"{0}\" Employee \"{1}\" Start time \"{2}\" End time \"{3}\" is \"not visib" +
                        "le\"", role, employee, startTime, endTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Daily total numbers equals sum of session totals")]
        [NUnit.Framework.TestCaseAttribute("QA", "Role 2", new string[] {
                "QA"}, Category="QA")]
        [NUnit.Framework.TestCaseAttribute("QA", "All Roles", new string[] {
                "QA"}, Category="QA")]
        public virtual void DailyTotalNumbersEqualsSumOfSessionTotals(string environment, string role, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Daily total numbers equals sum of session totals", null, exampleTags);
#line 60
    this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 61
        testRunner.Given(string.Format("LPH app is open on \"{0}\"", environment), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 62
        testRunner.When(string.Format("Role \"{0}\" is selected", role), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
        testRunner.Then("Verify Daily totals equal session totals", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Daily total pie chart percentages match daily total numbers")]
        [NUnit.Framework.TestCaseAttribute("QA", new string[] {
                "QA"}, Category="QA")]
        public virtual void DailyTotalPieChartPercentagesMatchDailyTotalNumbers(string environment, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Daily total pie chart percentages match daily total numbers", null, exampleTags);
#line 73
    this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 74
        testRunner.Given(string.Format("LPH app is open on \"{0}\"", environment), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 75
        testRunner.Then("Verify Daily Total pie chart percentages are correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Session pie chart percentages match session total numbers")]
        [NUnit.Framework.TestCaseAttribute("QA", new string[] {
                "QA"}, Category="QA")]
        public virtual void SessionPieChartPercentagesMatchSessionTotalNumbers(string environment, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Session pie chart percentages match session total numbers", null, exampleTags);
#line 82
    this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 83
        testRunner.Given(string.Format("LPH app is open on \"{0}\"", environment), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 84
        testRunner.Then("Verify Session pie chart percentages are correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test")]
        [NUnit.Framework.TestCaseAttribute("QA", new string[] {
                "QA"}, Category="QA")]
        public virtual void Test(string environment, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test", null, exampleTags);
#line 91
    this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 92
        testRunner.Given(string.Format("LPH app is open on \"{0}\"", environment), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 93
        testRunner.When("Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
