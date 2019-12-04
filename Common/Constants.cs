using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Constants
    {
        public const int BatchImportCount = 5;

        public const int OgranisationId = 1;

        public const int AnotherOgranisationId = 159;

        public static class Headers
        {
            public const string OrganizationHeader = "Authorization";

            public const string Reset = "reset";
        }
        public static class Data
        {
            public const string TenantDatabase = "TenantDatabase";

            public const string Location = "Location";

            public const string Employee = "Employee";

            public const string EmployeeAnotherOrganisation = "EmployeeAnotherOrganisation";

            public const string Employees = "Employees";

            public const string Locations = "Locations";

            public const string LocationAnotherOrganisation = "LocationAnotherOrganisation";

            public const string Departments = "Departments";

            public const string Department = "Department";

            public const string AnotherDepartmentSameLocation = "AnotherDepartmentSameLocation";

            public const string DepartmentAnotherLocationSameOrganisation = "DepartmentAnotherLocationSameOrganisation";

            public const string DepartmentAnotherOrganisation = "DepartmentAnotherOrganisation";

            public const string Organisation = "Organisation";

            public const string Areas = "Areas";

            public const string Area = "Area";

            public const string AreaAnotherOrganisation = "AreaAnotherOrganisation";

            public const string Role = "Role";

            public const string RoleAnoderOrganisation = "RoleAnoderOrganisation";

            public const string Roles = "Roles";

            public const string JobTitle = "JobTitle";

            public const string JobTitles = "JobTitles";

            public const string MainAssignment = "MainAssignment";

            public const string MainAssignmentAnotherOrganisation = "MainAssignmentAnotherOrganisation";

            public const string Shifts = "Shifts";

            public const string Shift = "Shift";

            public const string ShiftModel = "ShiftModel";

            public const string ShiftModelD = "ShiftModelD";

            public const string AnotherOrganisationShift = "AnotherOrganisationShift";

            public const string ShiftAnotherLocationSameOrganisation = "ShiftAnotherLocationSameOrganisation";

            public const string ShiftLocationAnotherOrganisation = "ShiftLocationAnotherOrganisation";

            public const string ShiftSameLocationAnotherDepartment = "ShiftSameLocationAnotherDepartment";

            public const string UpdatedShift = "UpdatedShift";

            public const string ShiftToDelete = "ShiftToDelete";

            public const string User = "User";

            public const string UserLevel = "UserLevel";

        }

        public static class Enpoints
        {
            public const string Locations = "locations";

            public const string Departments = "departments";

            public const string Shifts = "shifts";

            public const string From = "srom";

            public const string To = "to";

            public const string SchedulePeriod = "schedule-period";
        }

        public static class ErrorMessages
        {
            public const string MissingRecordInDatabase = "There is no record in the database";

            public const string UnexpectedRecordInDatabase = "There are unexpected records in the database";
        }
    }
}
