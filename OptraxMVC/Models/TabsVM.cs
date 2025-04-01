namespace OptraxMVC.Models
{
    public class TabsVM
    {
        public string Area { get; set; } = "";

        public List<Tab> Tabs { get; set; } = [];

        public void SetTabViewPath(Tab tab)
        {
            tab.ViewPath = $"~/Areas/{Area}/Views/{tab.Name}/_{tab.Name}.cshtml";
        }
    }

    public class Tab
    {
        public Tab(string name, int id)
        {
            ID = id;
            Name = name;
            TabKey = SetViewTabKey(name);
        }

        public Tab(string name, string? path = null, bool isViewTab = false)
        {
            Name = name;
            TabKey = isViewTab ? SetViewTabKey(name) : SetTopTabKey(name);
            ViewPath = path ?? SetTopTabPath(name);
        }

        public int? ID { get; set; }
        public string Name { get; set; }
        public string TabKey { get; set; }
        public string? ViewPath { get; set; }

        public string SetTopTabKey(string name)
        {
            return name[..3].ToLower() + "-" + name.Replace(" ", "").ToLower();
        }
        public string SetTopTabPath(string name)
        {
            return $"/{name}/Get{name}View/";
        }

        public string SetViewTabKey(string name)
        {
            return $"view-${name.Replace(" ", "").ToLower()}";
        }

        public string SetViewTabPath(string controller, string action)
        {
            return $"./{controller}/{action}/";
        }
    }
}
