using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MyWebApi.Middleware;

namespace MyWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices(services =>
                    {
                        services.AddControllers();
                    });
                    webBuilder.Configure(app =>
                    {
                        app.UseMiddleware<LoggingMiddleware>();  // Add logging middleware here
                        app.UseRouting();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                });
    }
}
