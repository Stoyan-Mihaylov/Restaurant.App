using MentorMate.Restaurant.App.Core;
using MentorMate.Restaurant.Business.Caches;
using MentorMate.Restaurant.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MentorMate.Restaurant.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var host = CreateHosting(args).Build();
            host.Services.GetService<IEngine>()!.Run();
        }

        public static IHostBuilder CreateHosting(string[] args)
            => Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services
                .AddTransient<IEngine, Engine>()
                .AddSingleton<ProductsCache>()
                .AddSingleton<OrdersCache>()
                .AddTransient<IOrderProductService, OrderProductService>();
            });
    }
}