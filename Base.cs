#nullable disable

using System;
using System.Text;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace Daria
{
    public class Base : BaseCommandModule
    {
        [Command("help")]
        [Aliases("info", "commands")]
        public async Task Help(CommandContext context)
        {
            await context.RespondAsync(new DiscordEmbedBuilder().WithTitle("Daria").WithDescription("***A snarky bot imitating the beloved TV character, Daria. Created by Pixelated_Lagg#8321.***\n\n**Commands:**\n*d.help* - Display this menu.\n*d.advice* - Ask for some advice."));
        }

        [Command("advice")]
        public async Task Advice(CommandContext context, params string[] args)
        {
            if (Program.Random.Next(0, 4) == 0)
            {
                await context.RespondAsync((Program.Random.Next(0, 3)) switch 
                {
                    0 => "Go away, I am currently regretting life desicions.",
                    1 => "Sorry, just found my old noise cancelling headphones.",
                    _ => "God, you humans sure make me want to go back to my home planet."
                });
                return;
            }
            if (args.Length == 0)
            {
                await context.RespondAsync((Program.Random.Next(0, 3)) switch 
                {
                    0 => "Hey, at least put in a little more effort to talk to me.",
                    1 => "Hallelujah! You have been blessed with the ability to speak, now use it.",
                    _ => "For the small amount of time that I am accepting conversation, you sure are wasting it."
                });
                return;
            }
            StringBuilder builder = new StringBuilder(args[0]);
            for (int i = 1; i < args.Length; i++)
            {
                builder.Append($" {args[i]}");
            }
            string message = builder.ToString().ToLower();
            foreach (string keyword in Responses.Entries.Keys)
            {
                if (message.Contains(keyword))
                {
                    await context.RespondAsync(Responses.Entries[keyword]);
                    return;
                }
            }
        }
    }
}