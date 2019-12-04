
using DataSeeding.Models;

namespace Tests.API.Models
{
    public class UpdateShiftModel : Tests.API.Models.DeleteShiftModel
    {
        public int ShiftId { get; set; }

        public string ChangeReason { get; set; }
    }
}
