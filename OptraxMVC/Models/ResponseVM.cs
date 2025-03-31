namespace OptraxMVC.Models
{
    public class ResponseVM
    {
        public ResponseVM() { }

        public ResponseVM(bool success) { Success = success; }

        public ResponseVM(string msg, bool success = false)
        {
            Success = success;
            Msg = msg;
        }

        public ResponseVM(object data)
        {
            Success = true;
            Data = data;
        }

        public bool Success { get; set; } = false;
        public string Msg { get; set; } = string.Empty;
        public string? Function { get; set; }
        public object? Data { get; set; }

        public Dictionary<string, string>? ModelError { get; set; }

    }

    public class StringResult
    {
        public string Value { get; set; } = string.Empty;
    }
}
