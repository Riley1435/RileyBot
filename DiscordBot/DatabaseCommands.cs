using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBot.Data;
using RileyBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RileyBot
{
    public class DatabaseCommands : ModuleBase<SocketCommandContext>
    {
        [Command("newuser")]
        public async Task NewUser(SocketUser user = null)
        {
            var socketUser = user ?? Context.Client.CurrentUser;
            using (RileyBotContext context = new RileyBotContext())
            {
                try
                {
                    context.Users.Add(new User
                    {
                        //UserId = socketUser.Id,
                        DiscordId = socketUser.Id,
                        Added = DateTime.Now
                    });
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    await ReplyAsync($"Error adding <@{socketUser.Id}>");
                }
                await ReplyAsync($"<@{socketUser.Id}> has been added successfully.");
            }
        }

    }
}
