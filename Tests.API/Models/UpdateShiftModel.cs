
using DataSeeding.Models;

namespace Tests.API.Models
{
    public class UpdateShiftModel : CreateShiftModel
    {
        public int ShiftId { get; set; }

        public string ChangeReason { get; set; }
    }
}
