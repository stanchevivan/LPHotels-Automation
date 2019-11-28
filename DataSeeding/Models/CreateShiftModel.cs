using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSeeding.Models
{
    public class CreateShiftModel
    {
        public int EmployeeId { get; set; }

        public int RoleId { get; set; }

        public int Break1Minutes { get; set; }

        public int Break2Minutes { get; set; }

        public int ShiftTypeId { get; set; }

        public string Notes { get; set; }

        public double ShiftPayFactor { get; set; }

        public bool IsPaidBreak1 { get; set; }

        public bool IsPaidBreak2 { get; set; }

        public bool IsShiftShort { get; set; }

        public int PublishAlertId { get; set; }

        public string PublishMessage { get; set; }

        public bool ShouldBePublished { get; set; }

        public bool IsPassive { get; set; }

        public int? PassiveShiftReasonId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public DateTime? Break1StartDateTime { get; set; }

        public DateTime? Break2StartDateTime { get; set; }
    }
}
