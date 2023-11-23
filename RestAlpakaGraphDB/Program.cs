var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the Neo4j driver
var graphDbSettings = builder.Configuration.GetSection("GraphDatabaseSettings");
var driver = GraphDatabase.Driver(
    graphDbSettings["Uri"],
    AuthTokens.Basic(graphDbSettings["Username"], graphDbSettings["Password"])
);
builder.Services.AddSingleton<IDriver>(driver);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();