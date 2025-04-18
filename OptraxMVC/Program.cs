using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Admin;
using OptraxMVC.Models;
using OptraxMVC.Models.Formatters;
using OptraxMVC.Services;
using OptraxMVC.Services.Grow;
using OptraxMVC.Services.Inventory;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OptraxContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"), x => x.UseNetTopologySuite());
});

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<OptraxContext>()
                                                     .AddDefaultTokenProviders();

//AesEncryptionHelper.Initialize(
//    builder.Configuration["Encryption:Key"] ?? string.Empty,
//    builder.Configuration["Encryption:IV"] ?? string.Empty
//);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.LogoutPath = "/Identity/Account/Logout";
});

builder.Services.AddControllersWithViews(options =>
{
    //options.ModelBinderProviders.Insert(0, new PlantEventModelBinderProvider());
})
.AddRazorRuntimeCompilation();

builder.Services.AddRazorPages();
builder.Services.AddMemoryCache();

builder.Services.AddScoped<IMapService, MapService>();
builder.Services.AddScoped<IPlantService, PlantService>();
builder.Services.AddScoped<IOptionsService, OptionsService>();
builder.Services.AddScoped<IResourceService, ResourceService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

builder.Services.AddScoped<IPhoneFormatter, PhoneFormatter>();

builder.Services.AddScoped(provider =>
{
    var phoneFormatter = provider.GetRequiredService<IPhoneFormatter>();

    var config = new MapperConfiguration(cfg =>
    {
        cfg.AddProfile(new MappingProfile(phoneFormatter));
    });

    config.AssertConfigurationIsValid(); // optional but helpful

    return config;
});

// Then register IMapper (per request)
builder.Services.AddScoped<IMapper>(provider =>
{
    var config = provider.GetRequiredService<MapperConfiguration>();
    return config.CreateMapper();
});



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


