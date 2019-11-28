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
namespace Tests.API.FeaturesAndSteps.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("ShiftsTests")]
    public partial class ShiftsTestsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ShiftsTests.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ShiftsTests", "\tAs a user \r\n\tI want to be able to save and edit shifts\r\n\tso that I can create a " +
                    "schedule", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("CreateShift endpoint should return correct results")]
        [NUnit.Framework.CategoryAttribute("CreateLocation")]
        [NUnit.Framework.CategoryAttribute("CreateArea")]
        [NUnit.Framework.CategoryAttribute("CreateRole")]
        [NUnit.Framework.CategoryAttribute("CreateDepartment")]
        [NUnit.Framework.CategoryAttribute("CreateJobTitle")]
        [NUnit.Framework.CategoryAttribute("CreateEmployee")]
        [NUnit.Framework.CategoryAttribute("CreateAssignment")]
        [NUnit.Framework.TestCaseAttribute("1.InTeFutureWithBreaks", "15", "25", "2021-12-02 08:09", "2021-12-02 10:09", null)]
        [NUnit.Framework.TestCaseAttribute("2.WithoutBreaks", "0", "0", "2021-12-02 08:09", "2021-12-02 10:09", null)]
        [NUnit.Framework.TestCaseAttribute("3.ShiftInThePast", "15", "25", "2019-11-15 08:09", "2019-11-15 10:09", null)]
        public virtual void CreateShiftEndpointShouldReturnCorrectResults(string testCase, string break1Minutes, string break2Minutes, string startDateTime, string endDateTime, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CreateLocation",
                    "CreateArea",
                    "CreateRole",
                    "CreateDepartment",
                    "CreateJobTitle",
                    "CreateEmployee",
                    "CreateAssignment"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CreateShift endpoint should return correct results", null, @__tags);
#line 21
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table1.AddRow(new string[] {
                        "Break1Minutes",
                        string.Format("{0}", break1Minutes)});
            table1.AddRow(new string[] {
                        "Break2Minutes",
                        string.Format("{0}", break2Minutes)});
            table1.AddRow(new string[] {
                        "StartDateTime",
                        string.Format("{0}", startDateTime)});
            table1.AddRow(new string[] {
                        "EndDateTime",
                        string.Format("{0}", endDateTime)});
#line 22
 testRunner.Given("NewShift is created to be imported", ((string)(null)), table1, "Given ");
#line 28
 testRunner.When("Create Shift endpoint is requested with CorrectData and <id>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then("The status code of the response should be 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
     testRunner.And("Created shift should be added in the db", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("CreateShift endpoint should return error when body\'s data is incorrect")]
        [NUnit.Framework.CategoryAttribute("CreateLocation")]
        [NUnit.Framework.CategoryAttribute("CreateArea")]
        [NUnit.Framework.CategoryAttribute("CreateAreaAnotherOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateRole")]
        [NUnit.Framework.CategoryAttribute("CreateRoleForAnotherOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateDepartment")]
        [NUnit.Framework.CategoryAttribute("CreateDepartmentAnotherLocationSameOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateJobTitle")]
        [NUnit.Framework.CategoryAttribute("CreateEmployee")]
        [NUnit.Framework.CategoryAttribute("CreateAnotherOrganisationEmployee")]
        [NUnit.Framework.CategoryAttribute("CreateAssignment")]
        [NUnit.Framework.TestCaseAttribute("1.WhenEmployeeIsInvalid", "shiftWithInvalidEmployeeId", "1234567", "15", "25", "2019-12-07 08:09", "2019-12-07 10:09", "\"oops, Some error happened.\"", null)]
        [NUnit.Framework.TestCaseAttribute("2.WhenEmployeeIsEmpty", "shiftWithInvalidEmployeeId", "1234567", "15", "25", "2019-12-07 08:09", "2019-12-07 10:09", "\"oops, Some error happened.\"", null)]
        [NUnit.Framework.TestCaseAttribute("3.WhenRoleIsInvalid", "shiftWithInvalidRoleId", "1234567", "15", "25", "2019-12-07 08:09", "2019-12-07 10:09", "\"The selected member of staff is not available for scheduling on this role on thi" +
            "s date\"", null)]
        [NUnit.Framework.TestCaseAttribute("4.WhenRoleIsEmpty", "shiftWithInvalidRoleId", "1234567", "15", "25", "2019-12-07 08:09", "2019-12-07 10:09", "\"oops, Some error happened.", null)]
        [NUnit.Framework.TestCaseAttribute("5.WhenEmployeeIsFromAnotherOrganisation", "shiftWithEmployeeFromAnotherOrganisation", "1234567", "15", "25", "2019-12-07 08:09", "2019-12-07 10:09", "\"The selected member of staff is not available for scheduling on this date\"", null)]
        [NUnit.Framework.TestCaseAttribute("6.WhenRoleIsFromAnotherOrganisation", "shiftWithRoleFromAnotherOrganisation", "1234567", "15", "25", "2019-12-07 08:09", "2019-12-07 10:09", "\"The selected member of staff is not available for scheduling on this role on thi" +
            "s date\"", null)]
        public virtual void CreateShiftEndpointShouldReturnErrorWhenBodysDataIsIncorrect(string testCase, string invalidData, string id, string break1Minutes, string break2Minutes, string startDateTime, string endDateTime, string errorMessage, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CreateLocation",
                    "CreateArea",
                    "CreateAreaAnotherOrganisation",
                    "CreateRole",
                    "CreateRoleForAnotherOrganisation",
                    "CreateDepartment",
                    "CreateDepartmentAnotherLocationSameOrganisation",
                    "CreateJobTitle",
                    "CreateEmployee",
                    "CreateAnotherOrganisationEmployee",
                    "CreateAssignment"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CreateShift endpoint should return error when body\'s data is incorrect", null, @__tags);
#line 49
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table2.AddRow(new string[] {
                        "Break1Minutes",
                        string.Format("{0}", break1Minutes)});
            table2.AddRow(new string[] {
                        "Break2Minutes",
                        string.Format("{0}", break2Minutes)});
            table2.AddRow(new string[] {
                        "StartDateTime",
                        string.Format("{0}", startDateTime)});
            table2.AddRow(new string[] {
                        "EndDateTime",
                        string.Format("{0}", endDateTime)});
            table2.AddRow(new string[] {
                        "EmployeeId",
                        string.Format("{0}", id)});
            table2.AddRow(new string[] {
                        "RoleId",
                        string.Format("{0}", id)});
#line 50
 testRunner.Given(string.Format("Shift is created to be imported with invalid data {0}", invalidData), ((string)(null)), table2, "Given ");
#line 58
 testRunner.When("Create Shift endpoint is requested with CorrectData and <id>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
 testRunner.Then("The status code of the response should be 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
  testRunner.And("Shift should not be added in the db", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("CreateShift endpoint should return error for incorrect dates")]
        [NUnit.Framework.CategoryAttribute("CreateLocation")]
        [NUnit.Framework.CategoryAttribute("CreateLocations")]
        [NUnit.Framework.CategoryAttribute("CreateArea")]
        [NUnit.Framework.CategoryAttribute("CreateAreaAnotherOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateRole")]
        [NUnit.Framework.CategoryAttribute("CreateRoleForAnotherOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateDepartment")]
        [NUnit.Framework.CategoryAttribute("CreateDepartmentAnotherLocationSameOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateJobTitle")]
        [NUnit.Framework.CategoryAttribute("CreateEmployee")]
        [NUnit.Framework.CategoryAttribute("CreateAnotherOrganisationEmployee")]
        [NUnit.Framework.CategoryAttribute("CreateAssignment")]
        [NUnit.Framework.TestCaseAttribute("2.WhenBreaksBiggerThenShift", "30", "30", "2025-12-07 01:09", "2025-12-07 02:00", "\"Shift must be longer than total break time added\"", null)]
        [NUnit.Framework.TestCaseAttribute("3.WhenBreakBiggerThenShift", "0", "60", "2025-12-07 02:09", "2025-12-07 03:00", "\"Shift must be longer than total break time added\"", null)]
        [NUnit.Framework.TestCaseAttribute("4.WhenShiftIsBeforeAssignmentStart", "15", "25", "2018-12-07 03:09", "2018-12-07 04:00", "\"The selected member of staff is not available for scheduling on this date\"", null)]
        [NUnit.Framework.TestCaseAttribute("5.WhenShiftEndIsBeforeShiftStart", "15", "25", "2025-12-07 06:09", "2025-12-07 05:00", "\"Shift must be longer than total break time added\"", null)]
        public virtual void CreateShiftEndpointShouldReturnErrorForIncorrectDates(string testCase, string break1Minutes, string break2Minutes, string startDateTime, string endDateTime, string errorMessage, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CreateLocation",
                    "CreateLocations",
                    "CreateArea",
                    "CreateAreaAnotherOrganisation",
                    "CreateRole",
                    "CreateRoleForAnotherOrganisation",
                    "CreateDepartment",
                    "CreateDepartmentAnotherLocationSameOrganisation",
                    "CreateJobTitle",
                    "CreateEmployee",
                    "CreateAnotherOrganisationEmployee",
                    "CreateAssignment"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CreateShift endpoint should return error for incorrect dates", null, @__tags);
#line 84
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table3.AddRow(new string[] {
                        "Break1Minutes",
                        string.Format("{0}", break1Minutes)});
            table3.AddRow(new string[] {
                        "Break2Minutes",
                        string.Format("{0}", break2Minutes)});
            table3.AddRow(new string[] {
                        "StartDateTime",
                        string.Format("{0}", startDateTime)});
            table3.AddRow(new string[] {
                        "EndDateTime",
                        string.Format("{0}", endDateTime)});
#line 85
 testRunner.Given("NewShift is created to be imported", ((string)(null)), table3, "Given ");
#line 91
 testRunner.When("Create Shift endpoint is requested with CorrectData and <id>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 92
 testRunner.Then("The status code of the response should be 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 94
  testRunner.And("Shift should not be added in the db", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("CreateShift endpoint should return error for overlaping shifts")]
        [NUnit.Framework.CategoryAttribute("CreateLocation")]
        [NUnit.Framework.CategoryAttribute("CreateLocations")]
        [NUnit.Framework.CategoryAttribute("CreateArea")]
        [NUnit.Framework.CategoryAttribute("CreateAreaAnotherOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateRole")]
        [NUnit.Framework.CategoryAttribute("CreateRoleForAnotherOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateDepartment")]
        [NUnit.Framework.CategoryAttribute("CreateDepartmentAnotherLocationSameOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateJobTitle")]
        [NUnit.Framework.CategoryAttribute("CreateEmployee")]
        [NUnit.Framework.CategoryAttribute("CreateAnotherOrganisationEmployee")]
        [NUnit.Framework.CategoryAttribute("CreateAssignment")]
        [NUnit.Framework.TestCaseAttribute("15", "25", "2025-11-17 08:09", "2025-11-17 10:09", "\"The shift could not be added because it overlaps with another\"", null)]
        public virtual void CreateShiftEndpointShouldReturnErrorForOverlapingShifts(string break1Minutes, string break2Minutes, string startDateTime, string endDateTime, string errorMessage, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CreateLocation",
                    "CreateLocations",
                    "CreateArea",
                    "CreateAreaAnotherOrganisation",
                    "CreateRole",
                    "CreateRoleForAnotherOrganisation",
                    "CreateDepartment",
                    "CreateDepartmentAnotherLocationSameOrganisation",
                    "CreateJobTitle",
                    "CreateEmployee",
                    "CreateAnotherOrganisationEmployee",
                    "CreateAssignment"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CreateShift endpoint should return error for overlaping shifts", null, @__tags);
#line 116
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table4.AddRow(new string[] {
                        "Break1Minutes",
                        string.Format("{0}", break1Minutes)});
            table4.AddRow(new string[] {
                        "Break2Minutes",
                        string.Format("{0}", break2Minutes)});
            table4.AddRow(new string[] {
                        "StartDateTime",
                        string.Format("{0}", startDateTime)});
            table4.AddRow(new string[] {
                        "EndDateTime",
                        string.Format("{0}", endDateTime)});
#line 117
 testRunner.Given("NewShift is created to be imported", ((string)(null)), table4, "Given ");
#line 123
     testRunner.And("Create Shift endpoint is requested with CorrectData and <id>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
     testRunner.And("The status code of the response should be 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table5.AddRow(new string[] {
                        "Break1Minutes",
                        string.Format("{0}", break1Minutes)});
            table5.AddRow(new string[] {
                        "Break2Minutes",
                        string.Format("{0}", break2Minutes)});
            table5.AddRow(new string[] {
                        "StartDateTime",
                        string.Format("{0}", startDateTime)});
            table5.AddRow(new string[] {
                        "EndDateTime",
                        string.Format("{0}", endDateTime)});
#line 125
     testRunner.And("NewShift is created to be imported", ((string)(null)), table5, "And ");
#line 131
 testRunner.When("Create Shift endpoint is requested with CorrectData and <id>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 132
 testRunner.Then("The status code of the response should be 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 134
  testRunner.And("Shift should not be added in the db", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("CreateShift endpoint should return error for incorrect locationId or departmentId" +
            "")]
        [NUnit.Framework.CategoryAttribute("CreateLocation")]
        [NUnit.Framework.CategoryAttribute("CreateLocations")]
        [NUnit.Framework.CategoryAttribute("LocationForAnotherOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateArea")]
        [NUnit.Framework.CategoryAttribute("CreateAreaAnotherOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateRole")]
        [NUnit.Framework.CategoryAttribute("CreateRoleForAnotherOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateDepartment")]
        [NUnit.Framework.CategoryAttribute("CreateDepartmentAnotherOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateDepartmentAnotherLocationSameOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateJobTitle")]
        [NUnit.Framework.CategoryAttribute("CreateEmployee")]
        [NUnit.Framework.CategoryAttribute("CreateAnotherOrganisationEmployee")]
        [NUnit.Framework.CategoryAttribute("CreateAssignment")]
        [NUnit.Framework.TestCaseAttribute("1.MissingLocation", "InvalidLocationId", "", "404", null)]
        [NUnit.Framework.TestCaseAttribute("2.InvalidLocation", "InvalidLocationId", "123456", "401", null)]
        [NUnit.Framework.TestCaseAttribute("3.MissingDepartment", "InvalidDepartmentId", "", "404", null)]
        [NUnit.Framework.TestCaseAttribute("4.InvalidDepartment", "InvalidDepartmentId", "123456", "404", null)]
        [NUnit.Framework.TestCaseAttribute("5.LocationAnotherOrganisation", "LocationFromAnatherOrganisation", "123456", "401", null)]
        [NUnit.Framework.TestCaseAttribute("6.DepartmentAnotherOrganisation", "DepartmentFromAnatherOrganisation", "123456", "404", null)]
        [NUnit.Framework.TestCaseAttribute("7.DepartmentFromAnatherLocationSameOrganisation", "DepartmentFromAnatherLocationSameOrganisation", "123456", "401", null)]
        public virtual void CreateShiftEndpointShouldReturnErrorForIncorrectLocationIdOrDepartmentId(string testCase, string data, string id, string code, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CreateLocation",
                    "CreateLocations",
                    "LocationForAnotherOrganisation",
                    "CreateArea",
                    "CreateAreaAnotherOrganisation",
                    "CreateRole",
                    "CreateRoleForAnotherOrganisation",
                    "CreateDepartment",
                    "CreateDepartmentAnotherOrganisation",
                    "CreateDepartmentAnotherLocationSameOrganisation",
                    "CreateJobTitle",
                    "CreateEmployee",
                    "CreateAnotherOrganisationEmployee",
                    "CreateAssignment"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CreateShift endpoint should return error for incorrect locationId or departmentId" +
                    "", null, @__tags);
#line 154
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 155
 testRunner.When(string.Format("Create Shift endpoint is requested with {0} and {1}", data, id), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 156
 testRunner.Then(string.Format("The status code of the response should be {0}", code), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update Shift")]
        public virtual void UpdateShift()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update Shift", null, ((string[])(null)));
#line 168
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 169
    testRunner.Given("1 shifts are created and saved into database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 170
     testRunner.And("Shift is updated to be imported", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 171
 testRunner.When("Update Shift endpoint is requested", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 172
 testRunner.Then("The status code of the response should be 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 173
     testRunner.And("Shift should be updated in the db", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete Shift")]
        [NUnit.Framework.CategoryAttribute("CreateLocation")]
        [NUnit.Framework.CategoryAttribute("CreateLocations")]
        [NUnit.Framework.CategoryAttribute("LocationForAnotherOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateArea")]
        [NUnit.Framework.CategoryAttribute("CreateAreaAnotherOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateRole")]
        [NUnit.Framework.CategoryAttribute("CreateRoleForAnotherOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateDepartment")]
        [NUnit.Framework.CategoryAttribute("CreateDepartmentAnotherOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateDepartmentAnotherLocationSameOrganisation")]
        [NUnit.Framework.CategoryAttribute("CreateJobTitle")]
        [NUnit.Framework.CategoryAttribute("CreateEmployee")]
        [NUnit.Framework.CategoryAttribute("CreateAnotherOrganisationEmployee")]
        [NUnit.Framework.CategoryAttribute("CreateAssignment")]
        [NUnit.Framework.CategoryAttribute("CreateShift")]
        public virtual void DeleteShift()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete Shift", null, new string[] {
                        "CreateLocation",
                        "CreateLocations",
                        "LocationForAnotherOrganisation",
                        "CreateArea",
                        "CreateAreaAnotherOrganisation",
                        "CreateRole",
                        "CreateRoleForAnotherOrganisation",
                        "CreateDepartment",
                        "CreateDepartmentAnotherOrganisation",
                        "CreateDepartmentAnotherLocationSameOrganisation",
                        "CreateJobTitle",
                        "CreateEmployee",
                        "CreateAnotherOrganisationEmployee",
                        "CreateAssignment",
                        "CreateShift"});
#line 190
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 191
    testRunner.Given("1 shifts are created and saved into database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 192
     testRunner.And("Delete Shift model is created to be imported", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 193
 testRunner.When("Delete Shift endpoint is requested", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 194
 testRunner.Then("The status code of the response should be 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 195
     testRunner.And("Shift should be deleted from db", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete Shift enpoind should return error with invalid locationId ordepartmentId")]
        public virtual void DeleteShiftEnpoindShouldReturnErrorWithInvalidLocationIdOrdepartmentId()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete Shift enpoind should return error with invalid locationId ordepartmentId", null, ((string[])(null)));
#line 197
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 198
 testRunner.When("Delete Shift endpoint is requested with <invalidData> and <id>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 199
 testRunner.Then("The status code of the response should be <code>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete Shift enpoind should return error with invalid shiftId")]
        public virtual void DeleteShiftEnpoindShouldReturnErrorWithInvalidShiftId()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete Shift enpoind should return error with invalid shiftId", null, ((string[])(null)));
#line 208
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 209
 testRunner.When("Delete Shift endpoint is requested with <invalidData> and <id>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 210
 testRunner.Then("The status code of the response should be <code>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
