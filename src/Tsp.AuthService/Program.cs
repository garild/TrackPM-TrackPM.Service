using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ElasticsearchSerilog;

namespace Tsp.AuthService
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
                    webBuilder.CaptureStartupErrors(true);
                    webBuilder.UseSerilog();
                    webBuilder.UseStartup<Startup>();
                });
                
    }
}
