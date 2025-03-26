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
        //public Tab() { }

        //public Tab(string name)
        //{
        //    Name = name;
        //    TabKey = GetTabKey(name);
        //}

        //public string Name { get; set; } = string.Empty;

        //public string TabKey { get; set; } = string.Empty;

        //public string? ViewPath { get; set; }

        //public string GetTabKey(string name)
        //{
        //    return name[..3].ToLower() + "-" + name.ToLower();
        //}

        public Tab(string name, bool setPath = true)
        {
            Name = name;

            TabKey = SetTabKey(name);
            if (setPath) { ViewPath = SetViewPath(name); }
        }

        public string Name { get; set; }
        public string TabKey { get; set; }
        public string? ViewPath { get; set; }

        public string SetTabKey(string name)
        {
            return name[..3].ToLower() + "-" + name.ToLower();
        }

        public string SetViewPath(string name)
        {
            return $"/{name}/Load{name}/";
        }
    }
}
