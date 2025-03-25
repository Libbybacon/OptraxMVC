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
        public Tab() { }

        public Tab(string name)
        {
            Name = name;
            TabKey = GetTabKey();
        }

        public string Name { get; set; } = string.Empty;

        public string TabKey { get; set; } = string.Empty;

        public string? ViewPath { get; set; }

        public string GetTabKey()
        {
            return Name[..3].ToLower() + "-" + Name.ToLower();
        }

    }
}
