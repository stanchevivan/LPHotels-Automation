using System;

namespace Tests.API.Models
{
    public class DeleteShiftModel
    {
        public int EmployeeId { get; set; }

        public string StaffForeignId { get; set; }

        public string Reason { get; set; }

        public DateTime Date { get; set; }
    }
}
