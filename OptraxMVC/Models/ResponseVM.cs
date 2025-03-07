namespace OptraxMVC.Models
{
    public class ResponseVM
    {
        public string msg { get; set; } = "";
        public bool success { get; set; } = false;
        public object? data { get; set; }
    }
}
