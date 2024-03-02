using BinanceWebSocketApi.Utils;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BinanceWebSocketApi.Abstractions;
using BinanceWebSocketApi.WebSocket;
using Newtonsoft.Json;

internal class Program
{
    private static async Task Main(string[] args)
    {
        static async Task RunBot(IServiceProvider services, string scope)
        {
            Console.WriteLine($"{scope}...");

            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            var binanceMessageHandler = provider.GetRequiredService<IBinanceMessageHandler>();
            var binanceWebSocketService = provider.GetRequiredService<IBinanceWebSocketService>();

            binanceMessageHandler.PriceUpdated += (sender, e) =>
            {
                Console.WriteLine($"Prix mis à jour pour {e.Symbol}: {e.ClosePrice}");
            };

            binanceMessageHandler.KlineUpdated += (sender, e) =>
            {
                Console.WriteLine($"Kline mis à jour pour {e.Symbol}: Ouverture {e.Kline.OpenPrice}, Fermeture {e.Kline.ClosePrice}");
            };

            await binanceWebSocketService.ConnectAsync("wss://stream.binance.com:9443/ws/solusdt@trade");

            var subscribeMessage = JsonConvert.SerializeObject(new
            {
                method = "SUBSCRIBE",
                @params = new[] { "solusdt@miniTicker", "solusdt@kline_1s" },
                id = 1
            });

            await binanceWebSocketService.SendAsync(subscribeMessage);
        }

        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<IBinanceWebSocketService, BinanceWebSocketService>();
                services.AddSingleton<IBinanceMessageHandler, BinanceMessageHandler>();
                services.AddSingleton<IFileSystem, FileSystem>();
                services.AddSingleton<ILogger, Logger>();
            });

        using IHost host = builder.Build();

        await RunBot(host.Services, "My singleton for BinanceBot is running...");

        Console.WriteLine();

        await host.RunAsync();

        Console.ReadLine();
    }
}