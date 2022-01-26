# Templates-net6-0.WebApp.SqlDb

- `dotnet aspnet-codegenerator razorpage -m Enrollment -dc MainContext -udl -outDir Pages\Enrollments --referenceScriptLibraries`
- `dotnet ef migrations add "Initial" --context MainContext --output-dir ./Data/Migrations`
