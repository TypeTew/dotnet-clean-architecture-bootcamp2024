### Migration
```bash
dotnet ef migrations add "initial01" --project .\Persistence --startup-project .\API --output-dir .\Migrations
dotnet ef database update --project .\Persistence --startup-project ./API

-- add auth
dotnet ef migrations add "add identity" --project .\Persistence --startup-project .\API --output-dir .\Migrations --context AuthDbContext
dotnet ef database update --project .\Persistence --startup-project ./API --context AuthDbContext

```

### The dotnet-ef tool must be install to use the database command
```bash
dotnet tool install --global dotnet-ef
```

### Add reference from the project 'Application' to the project 'API'
```bash
cd API
dotnet add reference ..\Application\ 
```

### Run
```bash
dotnet restore #Restore nuget packages
dotnet build #Build a project
dotnet watch run -p API #Run the project with hot reload
```

### dotnet add package <PACKAGE_NAME> #install a NuGet package
```bash
#For example, to install the Newtonsoft.Json package, 
#use the following command
dotnet add package Newtonsoft.Json
```

### JWT
```
dotnet add ./Application  package Microsoft.AspNetCore.App
dotnet add .\API package Microsoft.ASpNetCore.Authentication.JwtBearer
dotnet add .\API package System.IdentityModel.Tokens.Jwt
dotnet add .\API package Microsoft.IdentityModel.tokens
 
dotnet add .\Application package Microsoft.ASpNetCore.Authentication.JwtBearer
dotnet add .\Application package Microsoft.ASpNetCore.Identity.EntityFrameworkCore
 
dotnet add .\Persistence package Microsoft.ASpNetCore.Authentication.JwtBearer
dotnet add .\Persistence package Microsoft.ASpNetCore.Identity.EntityFrameworkCore
dotnet add .\Persistence package Microsoft.IdentityModel.tokens
dotnet add .\Persistence package System.IdentityModel.Tokens.Jwt
```

### Add reference
```
dotnet add "Application.test" reference "Application/Application.csproj"

 ```


### database connection string
```bash
"bootcampDatabase": "Server=localhost\MSSQLSERVER01;Database=bootcamp;User ID=test02;password=123456;TrustServerCertificate=True;Trusted_Connection=True"
```
