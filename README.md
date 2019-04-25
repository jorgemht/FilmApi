# FilmApi

## Projects

**Film Api**: [API with ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.2&tabs=visual-studio)

**FilmApi.Domain** The models of all the projects.

# Setup

**1. Clone or download the repository. Run the project in [visual studio.](https://visualstudio.microsoft.com)**

**2. Update your connection strings.**
```
"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_URLSERVER; 
    Database=YOUR_DATABASE; 
    User ID=YOUR_USERNAME; 
    Password=YOUR_PASSWORD; 
    Encrypt=true;
    Connection Timeout=30;"
  },  
```

**3. Apply the migration to the database to create the schema.**

```
Update-Database
```

# Requirements
 * [Visual Studio 2019](https://www.visualstudio.com/vs/)
 * Windows 10 or Mac
 * Microsoft Azure subscription
 * [.NET Core SDK 2.1](https://dotnet.microsoft.com/download/dotnet-core/2.1)

# Recommended links

 * [Connection strings](https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-strings)
 * [Migrations](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/)

# Clean and Rebuild

If you see build issues when pulling updates from the repo, try cleaning and rebuilding the solution.

# Copyright and license

The MIT License (MIT) see [License file](https://github.com/jorgemht/FilmApi/blob/master/LICENSE)


