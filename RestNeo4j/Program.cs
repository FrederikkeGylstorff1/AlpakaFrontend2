using WebApplication3;
using Config = Neo4j.Driver.Config;

public class Program
{
    public static async Task Main(string[] args)
    {
        // load config from appsettings.json
        var (uri, user, password) = Configuration.UnpackNeo4jConfig();

        // connect to Neo4J and Verify Connectivity
        await Neo4jDriver.InitDriverAsync(uri, user, password);

        // configure and run website
        await CreateHostBuilder(args).Build().RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}