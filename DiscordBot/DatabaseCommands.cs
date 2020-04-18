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
            var socketUser = user ?? Context.User;
            using (RileyBotContext context = new RileyBotContext())
            {
                try
                {
                    context.Users.Add(new User
                    {
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

        [Command("newdrop")]
        public async Task NewDrop(
            string name, 
            int killcount, 
            int points, 
            SocketUser user = null)
        {
            var socketUser = user ?? Context.User;
            using (RileyBotContext context = new RileyBotContext())
            {
                var id = context.Users.ToList();
                try
                {
                    context.Drops.Add(new Drop
                    {
                        Name = name,
                        KillCount = killcount,
                        Points = points,
                        UserId = context.Users.Where(u => u.DiscordId == socketUser.Id).FirstOrDefault().UserId
                    });
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    await ReplyAsync($"Error adding <@{socketUser.Id}'s Drop>");
                }
                finally
                {
                    await ReplyAsync($"<@{socketUser.Id}>'s Drop has been added successfully.");
                }
            }
        }


        [Command("drops")]
        public async Task DropsTable(SocketUser user = null)
        {
            var socketUser = user ?? Context.User;
            var drops = new List<Drop>();
            using (RileyBotContext context = new RileyBotContext())
            {
                var userData = context.Users.Where(u => u.DiscordId == socketUser.Id).FirstOrDefault();
                drops = context.Drops.Where(d => d.UserId == userData.UserId).ToList();

                drops = context.Drops.ToList();
                StringBuilder sb = new StringBuilder();
                foreach (var d in drops)
                {
                    sb.Append($"user: {d.UserId}, dropname: {d.Name}, ");
                }

                await ReplyAsync($"{sb.ToString()}");
            }
        }

    }
}
