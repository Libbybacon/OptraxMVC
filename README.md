![logo-lt](https://github.com/user-attachments/assets/04da5b57-4199-4a50-ba70-7b44f896b77e)   
<sup>***Seed to Sale Operations Tracking for Indoor Growers***</sup>

www.Optrax.dev

# History
The idea for this project is what initially led me into software development.  It started as an itch during the years I spent working in the cannabis 
industry in Oregon, and in 2018 I took up coding as a hobby to see if I could turn my idea into a reality.  Coincidentally, in 2019 one of my siblings
started his own cannabis business in Massachusetts where it had recently been legalized.  With his encouragement (and need for good
tracking software), I shifted all of my focus to my coding hobby which by then had become more of an obsession.  I left my job and moved in with my
Grandmother in Michigan in late 2020.   

While there I completed a boot camp, and in June 2021 I moved to a small town in Wyoming to begin my first official role as a 
software developer.  It was a small company (12 people!) with a heavy work load, and during my 3.5+ years there I gained experience working on every
aspect of building web applications - database design, UI/UX, working with clients, publishing to production sites, etc. - and eventually re-wrote the entire code base
for one of that company's three core products.  Much of my time outside of work was spent on.... also work, and my original project was left to gather dust.  

In February 2025 I left that company in search of a new opportunity with more room to grow and decided to finally breathe some life into the project that
started it all.  So here is 'Optrax' (nee GrowFlow - taken, of course) in its nascent form.  I don't know what its future holds, but will continue with regular updates
until I find a home at a new company or it becomes a production-ready application somewhere down the road.

# About

Optrax is an ASP.NET Core 8.0 MVC web application deployed on Microsoft Azure App Service, using an Azure SQL Database.

This platform is designed for use by cannabis industry growers to track individual plants from seed to sale, manage grow operations and inventory, and gain
insight through in-depth reporting.

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

