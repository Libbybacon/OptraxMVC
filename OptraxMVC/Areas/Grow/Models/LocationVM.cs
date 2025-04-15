using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Maps;
using OptraxMVC.Models.ViewModels;

namespace OptraxMVC.Areas.Grow.Models
{
    public class LocationVM
    {
        public LocationVM() { }
        public LocationVM(string type, int? parentId = null)
        {
            Location = SetLocation(type);
            Location.ParentId = parentId;
            LocationType = type;
            Tabs = SetTabs(Location);
        }

        public LocationVM(Location loc)
        {
            if (loc is Site site)
            {
                Site = site;
            }
            else if (loc is AreaLocation area)
            {
                AreaLocation = area;
            }
            else if (loc is AddressLocation addy)
            {
                AddressLocation = addy;
            }

            Location = loc;
            Tabs = SetTabs(loc);
            LocationType = loc.GetType().ToString();
        }

        public string LocationType { get; set; } = "Site";
        public Site? Site { get; set; }
        public AreaLocation? AreaLocation { get; set; }
        public AddressLocation? AddressLocation { get; set; }
        public Location Location { get; set; } = new Site();

        public Map? Map { get; set; }
        public List<Tab> Tabs { get; set; } = [];
        public bool ShowEdit { get; set; } = false;


        public List<Tab> SetTabs(Location loc)
        {
            int id = loc.Id;
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
            Location? loc;
            switch (type.ToLower())
            {
                case "field":
                    AreaLocation = new Field();
                    loc = AreaLocation;
                    break;
                case "greenhouse":
                    AreaLocation = new Greenhouse();
                    loc = AreaLocation;
                    break;
                case "building":
                    AddressLocation = new Building();
                    loc = AddressLocation;
                    break;
                case "room":
                    loc = new Room();
                    break;
                case "firstsite":
                    Site = new Site() { IsFirst = true, IsPrimary = true };
                    loc = Site;
                    break;
                default:
                    Site = new Site();
                    loc = Site;
                    break;
            }
            return loc;
        }

        public Location GetLocation()
        {
            if (Site != null)
            {
                return Site;
            }
            else if (AreaLocation != null)
            {
                return AreaLocation;
            }
            else if (AddressLocation != null)
            {
                return AddressLocation;
            }
            return Location;
        }
    }
}
