using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.OpenApi.Models;
using Neo4j.Driver;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Alpaka API", Version = "v1" });
});


// Configure the Neo4j driver
var graphDbSettings = builder.Configuration.GetSection("GraphDatabaseSettings");
var driver = GraphDatabase.Driver(
    graphDbSettings["Uri"],
    AuthTokens.Basic(graphDbSettings["Username"], graphDbSettings["Password"])
);
builder.Services.AddSingleton<IDriver>(driver);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();