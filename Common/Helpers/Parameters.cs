
namespace Common.Helpers
{
    public class Parameters
    {
        private string _value;

        public string Field { get; set; }

        public string Value
        {
            get => _value == "null" ? null : _value;
            set => _value = value;
        }
    }
}