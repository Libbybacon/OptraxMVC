namespace OptraxMVC.Models
{
    public class TabsVM
    {
        public required string Area { get; set; }

        public List<Tab> Tabs { get; set; } = [];

        public void SetTabViewPath(Tab tab)
        {
            tab.ViewPath = $"~/Areas/{Area}/Views/{tab.Name}/_{tab.Name}.cshtml";
        }
    }

    public class Tab
    {
        public Tab(string name, string? path = null, bool isViewTab = false)
        {
            Name = name;
            TabKey = isViewTab ? SetViewTabKey(name) : SetTabKey(name);
            ViewPath = !string.IsNullOrEmpty(path) ? path : SetViewPath(name);
        }

        public int? ID { get; set; }
        public string Name { get; set; }
        public string TabKey { get; set; }
        public string? ViewPath { get; set; }

        public string SetTabKey(string name)
        {
            return name[..3].ToLower() + "-" + name.Replace(" ", "").ToLower();
        }

        public string SetViewTabKey(string name)
        {
            return $"view-${name.Replace(" ", "").ToLower()}";
        }

        public string SetViewPath(string name)
        {
            return $"/{name}/Get{name}View/";
        }
    }
}
