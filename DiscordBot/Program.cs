using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();
            var appSettings = new AppSettings();
            configuration.GetSection("AppSettings").Bind(appSettings);

            var services = new ServiceCollection()
                .AddSingleton(new DiscordSocketClient())
                .AddSingleton(new CommandService())
                .BuildServiceProvider();

            var bot = new Bot(appSettings,
                services,
                services.GetService<DiscordSocketClient>(),
                services.GetService<CommandService>());

            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
