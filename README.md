![logo-lt](https://github.com/user-attachments/assets/04da5b57-4199-4a50-ba70-7b44f896b77e)   
<sup>***Seed to Sale Operations Tracking for Indoor Growers***</sup>

www.Optrax.dev

# About

Optrax is an ASP.NET Core 8.0 MVC web application deployed on Microsoft Azure App Service, with an Azure SQL Database.

This platform is designed to help growers track individual plants from seed to sale, manage grow operations and inventory, and gain insight through in-depth reporting.

The concept for this project began as an itch during my years working in the cannabis industry in Oregon, eventually inspiring me to turn my coding hobby/obsession into a career. 
Originally built in 2020 with Python/Django for use by a single company on the East Coast (and only run locally), the project gathered dust while I spent 3.5+ years as a software developer building vegetation management, mapping, and reporting software for a Wyoming-based company. 

After leaving that role in February 2025, I decided to revisit the project that started it all while exploring new career opportunities—rewriting it in C#, hosting it in the cloud, and expanding its capabilities.

**_🚧 Optrax is very much a work in progress, with new features being actively developed and refined. Expect ongoing improvements as the platform evolves!_**

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

