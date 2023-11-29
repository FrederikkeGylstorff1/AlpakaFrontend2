using Neo4j.Driver;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configure the Neo4j driver
var graphDbSettings = builder.Configuration.GetSection("GraphDatabaseSettings");
var driver = GraphDatabase.Driver(
    graphDbSettings["Uri"],
    AuthTokens.Basic(graphDbSettings["Username"], graphDbSettings["Password"])
);
builder.Services.AddSingleton<IDriver>(driver);
builder.Services.AddSingleton<AlpakaService>(s =>
{
    var neo4jUri = builder.Configuration["GraphDatabaseSettings:Uri"];
    var neo4jUsername = builder.Configuration["GraphDatabaseSettings:Username"];
    var neo4jPassword = builder.Configuration["GraphDatabaseSettings:Password"];
    return new AlpakaService(neo4jUri, neo4jUsername, neo4jPassword);
});

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