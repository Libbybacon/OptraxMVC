using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OptraxMVC.Models
{
    public class TabsVM
    {
        public required string Area { get; set; }

        public List<Tab> Tabs { get; set; } = [];

        public void SetTabViewPath(Tab tab)
        {
            tab.ViewPath = $"~/Areas/{Area}/Views/{tab.Name}/_{tab.Name}";
        }
    }

    public class Tab
    {
        public required string Name { get; set; }

        public required string TabKey { get; set; }

        public string? ViewPath { get; set; }

    }
}
