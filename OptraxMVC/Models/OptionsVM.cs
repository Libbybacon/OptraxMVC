using Microsoft.AspNetCore.Mvc.Rendering;
using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Grow;

namespace OptraxMVC.Models
{
    public class OptionsVM
    {
        public OptionsVM() { }

        public List<SelectListItem> UomSelects { get; set; } = [];
        public List<SelectListItem> StateSelects { get; set; } = [];
        public List<ContainerType> ContainerTypeList { get; set; } = [];
        public List<IconCollection> IconsList { get; set; } = [];


        public List<SelectListItem> PlantTypeSelects { get; set; } = [];
        public List<SelectListItem> PhaseSelects { get; set; } = [];
        public List<Crop> CropsList { get; set; } = [];
        public List<SelectListItem> CropSelects { get; set; } = [];
        public List<SelectListItem> OriginTypeSelects { get; set; } = [];

        public List<SelectListItem> CategorySelects { get; set; } = [];
        public List<SelectListItem> TopCategorySelects { get; set; } = [];
        public List<SelectListItem> StockTypeSelects { get; set; } = [];


        public List<SelectListItem> LocationSelects { get; set; } = [];
        public List<SelectListItem> LocSelectsByMultiTypes { get; set; } = [];
        public List<SelectListItem> RoomSelects { get; set; } = [];
        public List<SelectListItem> BuildingSelects { get; set; } = [];
        public List<SelectListItem> OffSiteSelects { get; set; } = [];
        public List<SelectListItem> ContainerLocSelects { get; set; } = [];
        public List<SelectListItem> AllLocationSelects { get; set; } = [];
        public List<SelectListItem> LocationTypeSelects { get; set; } = [];

    }
}
