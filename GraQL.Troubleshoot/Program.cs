using GraQL.Troubleshoot.Helper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer().RegisterGraphQLTypes();


var app = builder.Build();

app.MapGraphQL();

app.Run();
