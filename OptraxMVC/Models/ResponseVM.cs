namespace OptraxMVC.Models
{
    public class ResponseVM
    {
        public ResponseVM() { }
        public bool Success { get; set; } = false;
        public string Msg { get; set; } = string.Empty;
        public string? Function { get; set; }
        public object? Data { get; set; }

        public Dictionary<string, string>? ModelError { get; set; }
    }
}
