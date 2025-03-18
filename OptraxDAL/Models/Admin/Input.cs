namespace OptraxDAL.Models.Admin
{
    public class Input : TrackingBase
    {
        public Input() { }

        public int ID { get; set; }

        public string InputName { get; set; } = string.Empty;

        public string Value { get; set; } = string.Empty;
    }
}
