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
        public static class Headers
        {
            public const string OrganizationHeader = "X-Fourth-Org";

            public const string UserHeader = "X-Fourth-UserID";
        }
        public static class Data
        {
            public const string TenantDatabase = "TenantDatabase";

            public const string Location = "Location";

            public const string Employee = "Employee";

            public const string Employees = "Employees";

            public const string Locations = "Locations";

            public const string Departments = "Departments";

            public const string Department = "Department";

            public const string Organisation = "Organisation";

            public const string Areas = "Areas";

            public const string Area = "Area";

        }

        public static class ErrorMessages
        {
            public const string MissingRecordInDatabase = "There is not record in the database";
        }
    }
}
