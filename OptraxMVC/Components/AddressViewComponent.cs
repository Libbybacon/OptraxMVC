using Microsoft.AspNetCore.Mvc;
using OptraxDAL.Models.Admin;
using OptraxMVC.Services;

namespace OptraxMVC.Components
{
    public class AddressViewComponent(IOptionsService options) : ViewComponent
    {
        private readonly IOptionsService _Options = options;

        public async Task<IViewComponentResult> Invoke(Address address, string prefix = "Address", bool showEdit = false)
        {
            ViewData["States"] = await _Options.LoadOptions(["StateSelects"]);
            ViewData.TemplateInfo.HtmlFieldPrefix = prefix;
            ViewData["Editable"] = showEdit;

            return View(address);
        }
    }
}
