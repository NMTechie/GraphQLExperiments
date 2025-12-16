using GraphQL.Application;
using GraphQL.Infrastructure.Persistence;
using GraphQL.Presentation.GraphQL;


var builder = WebApplication.CreateBuilder(args);
//Wiring the DI for Application Layer
builder.Services.AddApplicationLayer(builder.Configuration);

/* One way - Register the GraphQL server and at least one Query type */
//builder.AddGraphQL().AddTypes(new[] { typeof(Query) });


/* Another way - Register the GraphQL server and at least one Query type */
//builder.Services.AddGraphQLServer().AddTypes(new[] { typeof(Query) });
//OR
//builder.Services.AddGraphQLServer().AddQueryType<Query>();
//builder.Services.AddGraphQLServer().RegisterGraphQLTypes();
builder.Services.RegisterGraphQLDependencies();

//Wiring the DI for SQLServer DbContext through Infrastructure layer putting
//my presentation layer to be clean
builder.Services.AddInfrastructure(builder.Configuration);


/*Build the App from builder*/
var app = builder.Build();
app.MapGraphQL();

app.Run();



