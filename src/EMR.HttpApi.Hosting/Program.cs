using System.Threading.Tasks;
using EMR.ToolKits.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace EMR.HttpApi.Hosting
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args).UseLog4Net()
                       .ConfigureWebHostDefaults(builder =>
                       {
                           builder.UseIISIntegration()
                                  .UseStartup<Startup>();
                       }).UseAutofac().Build().RunAsync();
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.UseStartup<Startup>();
              })
              .UseAutofac()
              .UseSerilog();
    }
}