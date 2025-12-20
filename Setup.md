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

Now I have an intersting issue in reference to clean architecture with greendonut.data querycontext ..... 
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

[Edited] : After lot of research, It is evident that I could have my domain entites to be decoared with 
System.componentmodel.dataannotations attributes to map with the DB tables and columns. Now this namespace is nothing to do 
with EFCore. So, I could have my domain entities in the domain layer decorated with these attributes and then use those domain entities 
in the infrastructure layer DbContext as DbSet<TEntity>. This way I could have my domain entities mapped with DB tables and columns
without having any dependency of EFCore in the domain layer. This way I could have clean architecture with DB first approach.Also well geled 
with the hotchocolate greendonut data loader mechanism. The catch is that I need to make sure that my domain entities are not polluted 
with any other attributes. Also donot use querycontext directly in the graphQL query resolvers. 
Instead use it [UseProjection]->[UseFiltering]->[UseSorting] attributes (which is basically middlewares) and graphQL dataloader will
take care of rest of the things.


In case of Mutation, everything is at top level and everything underthat top level is Query. So this implies that Mutation resolvers
will have parameter as input type maaped to the top level properties of the mutation.
In our case for Project mutation we will have inputs that relates to the Project DB Entity not the ProjectAggregate domain entity.But it 
could return ProjectAggregate domain entity as output.
This makes sense to me , so Project being added to DB and no task and obviously no comments at that time of creation. Later on client could 
add tasks and comments.However while returning the ProjectAggregate domain entity from the mutation resolver we will see that newly created
project will have empty tasks and comments list which is essentially true from business flow as well.
---> Based on the nullabletypes definition GraphQL will undestand what is required and what is not during mutation.
---> Another consideration while working on the mution part. If our domain entity have some calculated fields or non animic i.e 
has domain business logic behaviour then we should have a DTO for mutation input type rather than using the domain entity directly. 
This way we can keep our client clean and not pushing to think about the domain logic. In our case, created date is field that can be a user
input in any scenario but should be returned for viewing. Thus crerating a DTO for mutation input type makes sense to handle this.

For exception handling in graphQL HotChocolate already provides Hotchocolate.GraphQLException class which is derived from base exception class.
So in all our layers we could use this exception class to throw exceptions. The in the presentation layer in each graphQL resolver we could catch this exception 
and handle it appropriately to return the error messages by throwing to client by wrapping it as Hotchocolate.GraphQLException. 
This way we could have consistent exception handling mechanism across all layers and details of exception would only reside in server 
never goes out.
----> If you need more flexibility then look into IErrorFilter interface to customize the error messages globally.




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
Thus, I thought of having a helper console app only for scaffolding purposes to minimize unnecessary dependencies and keep things clean.

How EF Understands Identity Columns by Convention
===================================================
Conventions in EF:
If a property named Id or {ClassName}Id is of type int, long, etc., and is marked as [Key] or is the only 
property named Id, EF assumes this column is the primary key and, by default, will be auto-generated by the database.
You don’t need to set its value when inserting. EF knows not to send a value—the database will generate it.

During Insert (What Does EF Do?)
Creating a new entity:
C#
var project = new Project { Name = "TestProject" /*, Id is null by default */ };
context.Projects.Add(project);
context.SaveChanges();
EF will NOT submit the Id column in the SQL INSERT statement, because it expects the DB to generate it regardless 
of property “nullable” status.
SQL Server always generates the value and returns it after the insert.
3. What About Nullable vs. Non-Nullable in EF Model?
Nullable (int? Id) and non-nullable (int Id) both work for identity columns in this scenario—EF will treat null 
as “value not known/provided.”
After insertion, EF updates the entity’s Id property with the value from the DB.
For a nullable property, it sets the Id to non-null.
No error occurs. You will never have an entity with Id == null after a successful insert.