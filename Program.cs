using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;

namespace Daria
{
    class Program
    {
        public static Random Random = new Random();
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = Token.Value,
                TokenType = TokenType.Bot,
                
            });
            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            { 
                StringPrefixes = new[] { "d." },
                EnableDefaultHelp = false
            });
            commands.RegisterCommands<Base>();
            discord.MessageCreated += MessageCreated;
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
        static async Task MessageCreated(DiscordClient client, MessageCreateEventArgs args)
        {

        }
    }
}