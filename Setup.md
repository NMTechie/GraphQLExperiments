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
[so in nutshell the hotchocolate cursor pagination takes overhead from developer of forming sql queries for seek 
and also kind of making query dynamic automatically , but if your DB index is not optimized then it ultimately boils 
down to the fact to optimize your DB index based on your client data search mechanism

having said that it is not that useful as the publisher of data still need to control how the DB need to be optimized and 
for obvious reason publisher want to restrict how you could query with a tradeoff between flexibility vs response time 
]
🔹 Error handling in GraphQL
🔹 Mapping between Domain types and EFCore Entity types with expression builder to remove the leak/pollution about strcitness of clean arch

https://www.youtube.com/watch?v=YL07NyBXC7M
https://www.youtube.com/watch?v=iOQ74eYU2U4&list=PLA8ZIAm2I03g9z705U3KWJjTv0Nccw9pj

In Hot Chocolate 15, we rethought and rewrote the GreenDonut (DataLoader) implementation and 
introduced some new packages that provide a few primitives to pass between layers while keeping 
them isolated.(https://chillicream.com/blog/2025/02/01/hot-chocolate-15)

now I have an intersting issue in reference to clean archiyecture with greendonut.data querycontext ..... 
My presentaon layer where graphql queries are defined only knows about domain entities however in the dbcontext in the 
infrstructire layer it operated on the DB entities ..... 
Now How could I use the querycontext here to control the sql query as per the selection of the fields by the clients
[Ans]-> This is an excellent and advanced Clean Architecture/GraphQL/GreenDonut question.
You’re describing a problem most teams hit when combining:--- so this is not easy ..... further what I realise that this fetching 
problem going to be solved between your graphQL server and DB ..... that barely maters 

Further if you need to use QueryContext then need to install 
Hotchocolate.data package and version should be same across

Now as I dive deep it is getting clear that if you use graphQL the your underlying data structure is coupled with 
client exposure. The hotchocolate with its greendonut data provider implementation is pretty coupled with EFCore entites 
for taking the best advantage of it. In case of clean architecture this is going little messy as EFCore entities now been treated as 
your domain entities as well. This is fine when you expose those for data sharing mechanism internally. But definitely goign to be 
cumbersome when you need to expose different data structure to clients.

============ Setting up the Entity Framework in new Project =============
Microsoft.EntityFrameworkCore (max version compatible with .net 8 is 9.0.11)
Microsoft.EntityFrameworkCore.Tools (max version compatible with .net 8 is 9.0.11)
Microsoft.EntityFrameworkCore.SQLServer (max version compatible with .net 8 is 9.0.11)

All the above three is required to run the scaffolding command
Scaffold-DbContext "Server=localhost,1433;Database=Experiments;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -Project HelperConsoleApp -StartupProject HelperConsoleApp -OutputDir Persistence -Context ExperimentDbContext -DataAnnotations -NoOnConfiguring -namespace GraphQL.Infrastructure.Persistence.Sqlserver

Using the helper console app for clean EF Core scaffolding. After understnading the how dependencies resolved in build time through nuget and
how actually dlls are copied to the executable project, It is evident that the presentation layer wil ultimately have all the dlls. 
Now, instead of helper console app I can only 
- have the infrastructure layer with all the EFCore dependencies -> But that pollutes the infrastructure layer with unnecessary dependencies
                                                                    with Microsoft.EntityFrameworkCore.Tools and Microsoft.EntityFrameworkCore.Design
                                                                    which is not required for DB first approach.
- have the common layer with all the EFCore dependencies -> But that pollutes the common layer with unnecessary dependencies
                                                                    with Microsoft.EntityFrameworkCore.Tools and Microsoft.EntityFrameworkCore.Design
                                                                    which is then going to be available across all layers which is also bad. 
Thus, I thought of having a helper console app only for scaffolding purposes to minimize unnecessary dependencies and things clean.