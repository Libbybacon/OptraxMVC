![logo-lt](https://github.com/user-attachments/assets/04da5b57-4199-4a50-ba70-7b44f896b77e)   
<sup>***Seed to Sale Operations Tracking for Cut Flower Growers***</sup>

www.Optrax.dev

# About

Optrax is an ASP.NET Core 8.0 MVC web application deployed on Microsoft Azure App Service, with an Azure SQL Database.

This platform is designed to help growers track individual plants from seed to sale, manage grow operations and inventory, and gain insight through in-depth reporting.

**_Please Note: Optrax is very much a work in progress, with new features being actively developed and refined. Expect ongoing improvements as the platform evolves_**  

  ## Technology Stack
  
  - **Backend**: .NET 8 (MVC, Entity Framework Core)
  - **Frontend**: Razor Views, JavaScript, Bootstrap
  - **Database**: SQL Server
  - **Authentication**: Identity, JWT (if applicable)
  - **Cloud / Hosting**: Azure / AWS (optional)  
  
# Getting Started  
  
**Required Packages**     
Microsoft.AspNetCore.Identity.EntityFrameworkCore(8.0.13)  
Microsoft.EntityFrameworkCore(8.0.13)  
Microsoft.EntityFrameworkCore.SqlServer(8.0.13)  
Microsoft.EntityFrameworkCore.Tools(8.0.13)  

**_**Add your connection string in appsettings.json_**  

## Code First Migration  
dotnet ef migrations add InitialCommit --project OptraxDAL --startup-project OptraxMVC   
dotnet ef database update --project OptraxDAL --startup-project OptraxMVC  

# App Sections 

- [Administration](#-administration)
- [Grow](#-grow)

# Administration
  ## Locations
    
# Grow
  ## Map
  Add points, lines, and polygons to the interactive map to represent features of your growing locations.  
  
  Map objects can be linked to Sites, Buildings, Greenhouses, Fields, Rows, Beds, Plots, and Rooms configured in [Administration > Location](#-locations) at any time.



