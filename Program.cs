using AutoMapper;
using graphql_dotnet.Data;
using graphql_dotnet.Dto;
using graphql_dotnet.Entities;
using graphql_dotnet.GraphQL.Mutations;
using graphql_dotnet.GraphQL.Types;
using graphql_dotnet.Repositories;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Register Service
builder.Services.AddScoped<IProductService, ProductService>();

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = configuration.GetConnectionString("YourConnectionStringKey");

//InMemory Database
builder.Services.AddDbContext<DbContextClass>
(o => o.UseNpgsql(connectionString));


//GraphQL Config
builder.Services.AddGraphQLServer()
    .AddQueryType<ProductQueryTypes>()
    .AddMutationType<ProductMutations>();


var app = builder.Build();

//GraphQL
app.MapGraphQL();

app.UseHttpsRedirection();

app.Run();
