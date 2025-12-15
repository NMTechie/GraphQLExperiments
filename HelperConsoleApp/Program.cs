// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

Console.WriteLine("Hello, World!");

Console.WriteLine("Configuration value for 'ConnectionString': " + config["ConnectionStrings:DefaultConnection"]);
