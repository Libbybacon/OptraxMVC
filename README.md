![logo-lt](https://github.com/user-attachments/assets/04da5b57-4199-4a50-ba70-7b44f896b77e)   
<sup>***Seed to Sale Operations Tracking for Indoor Growers***</sup>

www.Optrax.dev

# Getting Started  
  
**Required Packages**     
Microsoft.AspNetCore.Identity.EntityFrameworkCore(8.0.13)  
Microsoft.EntityFrameworkCore(8.0.13)  
Microsoft.EntityFrameworkCore.SqlServer(8.0.13)  
Microsoft.EntityFrameworkCore.Tools(8.0.13)  

**_**Update connection string in appsettings.json_**  

## Code First Migration  
dotnet ef migrations add InitialCommit --project OptraxDAL --startup-project OptraxMVC   
dotnet ef database update --project OptraxDAL --startup-project OptraxMVC  

