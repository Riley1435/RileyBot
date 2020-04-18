using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// TODO: Shows all points that a user has.
        /// </summary>
        /// <returns></returns>
        [Command("points")]
        public async Task Points()
        {
            await ReplyAsync("You have 10 points");
        }

        [Command("user")]
        public async Task UserInfo(SocketUser user = null)
        {
            var userInfo = user ?? Context.User;
            await ReplyAsync($"{userInfo.Username} - {userInfo.Discriminator}");
        }

        /// <summary>
        /// TODO: Shows all available commands.
        /// </summary>
        /// <returns></returns>
        [Command("help")]
        [Summary("Shows command")]
        public async Task Help()
        {
            await ReplyAsync("show help message");
        }

        /// <summary>
        /// Ping test command.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Command("test")]
        public async Task TestAsync(SocketUser user = null)
        {
            if (user != null)
            {
                await ReplyAsync($"Ping test <@{user.Id}>");
            }
            else
            {
                await ReplyAsync("Please select a user to ping test");
            }
        }

        /// <summary>
        /// Pings a user and lets them know they are cleaned.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Command("cleaned")]
        public async Task CleanedAsync(SocketUser user = null)
        {
            if (user != null)
            {
                await ReplyAsync($"<@{user.Id}> has just been cleaned.");
            }
            else
            {
                await ReplyAsync("Please ping to clean.");
            }
        }

        /// <summary>
        /// Adds emojis to a message to allow users to vote.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [Command("vote")]
        public async Task AddVotesEmojisAsync([Remainder]string message)
        {
            if (!string.IsNullOrEmpty(message.ToString()))
            {
                var yesEmoji = new Emoji("✅");
                var noEmoji = new Emoji("❌"); 
                await Context.Message.AddReactionAsync(yesEmoji);
                await Context.Message.AddReactionAsync(noEmoji);
            }
            else
            {
                await ReplyAsync("Please enter a message.");
            }
        }

        /// <summary>
        /// Changes a user's nickname in the Discord guild.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [Command("name")]
        public async Task ChangeNickname(SocketUser user, string message)
        {
            if (user != null && !string.IsNullOrEmpty(message))
            {
                var guildUser = Context.Guild.GetUser(user.Id);
                await guildUser.ModifyAsync(x => { x.Nickname = message; });
                await ReplyAsync("Nickname Updated.");
            }
            else
            {
                await ReplyAsync("Please ping a user with a desired nickname.");
            }
        }
    }
}
