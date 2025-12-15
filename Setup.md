Install HotChocolatey.aspnetcore
Install-Package HotChocolate.AspNetCore -Version 13.3.1 (Auto discovery is possible however dropped from v15 onwards)

The first grpahql query 
query Nilesh1($input: String="Deafult")
{
    sayHello(greetings: $input)
}
graphQL var 
{
"name" : "The input value"
}

Need to cover this
🔹 GraphQL SDL schema
🔹 SQL indexes optimized for GraphQL resolvers
🔹 Soft deletes (is_deleted)
🔹 Audit fields (updated_at, updated_by)
🔹 Sample GraphQL queries/mutations
🔹 SQL Server views for GraphQL
🔹 Pagination strategies (offset-based, cursor-based)
🔹 Error handling in GraphQL

https://www.youtube.com/watch?v=YL07NyBXC7M
https://www.youtube.com/watch?v=iOQ74eYU2U4&list=PLA8ZIAm2I03g9z705U3KWJjTv0Nccw9pj

============ Setting up the Entity Framework in new Project =============
Microsoft.EntityFrameworkCore (max version compatible with .net 8 is 9.0.11)
Microsoft.EntityFrameworkCore.Tools (max version compatible with .net 8 is 9.0.11)
Microsoft.EntityFrameworkCore.SQLServer (max version compatible with .net 8 is 9.0.11)

Scaffold-DbContext "Server=localhost,1433;Database=Experiments;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -Project HelperConsoleApp -StartupProject HelperConsoleApp -OutputDir Persistence -Context ExperimentDbContext -DataAnnotations -NoOnConfiguring -namespace GraphQL.Infrastructure.Persistence.Sqlserver

Using the helper console app for clean EF Core scaffolding