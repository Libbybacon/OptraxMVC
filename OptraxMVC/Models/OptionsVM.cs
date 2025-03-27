﻿using Microsoft.AspNetCore.Mvc.Rendering;
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

        public List<SelectListItem> CatSelects { get; set; } = [];
        public List<SelectListItem> TopCatSelects { get; set; } = [];
        public List<SelectListItem> StockTypeSelects { get; set; } = [];


        public List<SelectListItem> LocTypeSelects { get; set; } = [];
        public List<SelectListItem> LocSelectsAll { get; set; } = [];
        public List<SelectListItem> LocSelectsByType { get; set; } = [];
        public List<SelectListItem> LocSelectsByLevel { get; set; } = [];

    }
}
