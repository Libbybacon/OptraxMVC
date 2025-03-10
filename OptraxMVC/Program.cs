using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Admin;
using OptraxMVC.Services;
using OptraxMVC.Services.Inventory;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OptraxContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<OptraxContext>()
                                                     .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.LogoutPath = "/Identity/Account/Logout";
});

builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

builder.Services.AddRazorPages();
builder.Services.AddScoped<IDropdownService, DropdownService>();
builder.Services.AddScoped<IItemService, InventoryService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IPlantService, PlantService>();
//builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddMemoryCache();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseStaticFiles(new StaticFileOptions
    {
        OnPrepareResponse = ctx =>
        {
            ctx.Context.Response.Headers.Append("Cache-Control", "no-store, no-cache, must-revalidate, max-age=0");
            ctx.Context.Response.Headers.Append("Pragma", "no-cache");
            ctx.Context.Response.Headers.Append("Expires", "0");
        }
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();


