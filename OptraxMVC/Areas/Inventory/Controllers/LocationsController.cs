using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxMVC.Controllers;
using OptraxMVC.Services.Inventory;
using OptraxMVC.Services;

namespace OptraxMVC.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class LocationsController(OptraxContext context, IDropdownService dropdownService, ILocationService locationService) : BaseController(context)
    {
        private readonly ILocationService _ILocation = locationService;
        private readonly IDropdownService _IDropdowns = dropdownService;


        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                var data = await _ILocation.GetLocationsAsync();

                return Json(data);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }
    }
}
