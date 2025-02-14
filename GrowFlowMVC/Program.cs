using Microsoft.EntityFrameworkCore;
using GrowFlow.Models;
using GrowFlowMVC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GrowFlowContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GrowFlowConnection"));
});

builder.Services.AddControllersWithViews()
                .AddRazorOptions(options =>
                {
                    options.AreaViewLocationFormats.Clear();
                    options.AreaViewLocationFormats.Add("/Areas/{2}/Views/{1}/{0}.cshtml");  // Look in Area first
                    options.AreaViewLocationFormats.Add("/Areas/{2}/Views/Shared/{0}.cshtml"); // Shared in Area
                    options.AreaViewLocationFormats.Add("/Views/{1}/{0}.cshtml");  // Look in global Views folder
                    options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");  // Global Shared views
                })
                .AddRazorRuntimeCompilation();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "Grow",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
