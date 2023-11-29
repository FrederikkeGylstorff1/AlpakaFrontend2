namespace WebApplication3;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // add api controllers
        services.AddControllers();
        // add jwt authorization/authentication
        
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        // add static file serving for vue app
        app.UseFileServer();
        app.UseRouting();
        // add auth 
        app.UseAuthentication();
        app.UseAuthorization();
        // register controllers
        app.UseEndpoints(builder => builder.MapControllers());
    }
}