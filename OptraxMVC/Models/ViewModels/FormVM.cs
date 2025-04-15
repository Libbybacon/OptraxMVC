namespace OptraxMVC.Models.ViewModels
{
    public class FormVM
    {
        public FormVM() { }

        public FormVM(string action, string type)
        {
            IsNew = action.Contains("create", StringComparison.CurrentCultureIgnoreCase);
            Action = action;
            Type = type;
        }

        public bool IsNew { get; set; } = true;
        public string? JsFunc { get; set; }
        public string? Action { get; set; }
        public string? MsgDiv { get; set; }

        public string? Type { get; set; }
    }
}
