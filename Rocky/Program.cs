using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Rocky
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // В этом методе мы создаем хост, который будет запускать наше приложение как ASP.NET Core приложение
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
