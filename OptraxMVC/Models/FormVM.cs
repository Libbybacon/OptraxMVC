namespace OptraxMVC.Models
{
    public class FormVM
    {
        public bool IsNew { get; set; } = true;
        public string? JsFunc { get; set; }
        public string? Action { get; set; }
        public string? MsgDiv { get; set; }
    }
}
