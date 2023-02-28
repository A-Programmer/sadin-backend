# CMS


## Adding migrations:
dotnet ef --startup-project Website.Api/Website.Api.csproj migrations add "Blog3" -p Website.Infrastructure/Website.Infrastructure.csproj


## Updates:  
Entity configurations for blog entities are created.  
- **I think I don't need to have relationship from `Category` to `Post`.**