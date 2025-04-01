using Microsoft.AspNetCore.Mvc;
using OptraxDAL.Models.Admin;
using OptraxMVC.Services;

namespace OptraxMVC.Components
{
    public class AddressViewComponent(IOptionsService options) : ViewComponent
    {
        private readonly IOptionsService _Options = options;

        public async Task<IViewComponentResult> InvokeAsync(Address address, bool showEdit = false, string prefix = "Address")
        {
            ViewData["States"] = (await _Options.LoadOptions(["StateSelects"])).StateSelects;
            ViewData.TemplateInfo.HtmlFieldPrefix = prefix;
            ViewData["ShowEdit"] = showEdit;

            return View(address);
        }
    }
}
