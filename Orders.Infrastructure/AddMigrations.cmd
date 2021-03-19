dotnet ef migrations add SchemaUpdate --startup-project ../Orders.API --output-dir Persistence\Migrations
dotnet ef database update  --startup-project ../Orders.API 
