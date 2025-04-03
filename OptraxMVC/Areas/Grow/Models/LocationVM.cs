using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Maps;
using OptraxMVC.Models;

namespace OptraxMVC.Areas.Grow.Models
{
    public class LocationVM
    {
        public LocationVM() { }
        public LocationVM(string type, int? parentID = null)
        {
            Location = SetLocation(type);
            Location.ParentID = parentID;
            Tabs = SetTabs(Location);
        }

        public LocationVM(Location loc)
        {
            Location = loc;
            Tabs = SetTabs(loc);
        }

        public Location Location { get; set; } = new Site();
        public Map? Map { get; set; }
        public List<Tab> Tabs { get; set; } = [];
        public bool ShowEdit { get; set; } = false;


        public List<Tab> SetTabs(Location loc)
        {
            int id = loc.ID;
            List<Tab> tabs = [new Tab("Details", id)];

            if (loc is AreaLocation)
            {
                tabs.Add(new Tab("Plantings", id));
            }
            tabs.Add(new Tab("Resources", id));

            return tabs;
        }

        public Location SetLocation(string type)
        {

            Location loc = type.ToLower() switch
            {
                "site" => new Site(),
                "field" => new Field(),
                "greenhouse" => new Greenhouse(),
                "building" => new Building(),
                "room" => new Room(),
                "firstsite" => new Site() { IsFirst = true, IsPrimary = true },
                _ => new Site(),
            };


            return loc;
        }
    }
}
