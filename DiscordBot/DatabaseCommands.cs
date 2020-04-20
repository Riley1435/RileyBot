using Discord;
using Discord.Commands;
using Discord.WebSocket;
using RileyBotDatabaseLibrary.Data;
using RileyBotDatabaseLibrary.Models;
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
        #region User Commands
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

        [Command("users")]
        public async Task UsersTable(SocketUser user = null)
        {
            var socketUser = user ?? Context.User;
            using (RileyBotContext context = new RileyBotContext())
            {
                var users = context.Users.ToList();
                StringBuilder sb = new StringBuilder();
                foreach (User u in users)
                {
                    sb.Append($"DiscordId: {u.DiscordId}, ");
                }

                await ReplyAsync($"{sb.ToString()}");
            }
        }
        #endregion

        #region Drop Commands
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
        #endregion

        #region Link Commands
        [Command("newlink")]
        public async Task NewLink(
            string link,
            SocketUser user = null)
        {
            var socketUser = user ?? Context.User;
            using (RileyBotContext context = new RileyBotContext())
            {
                try
                {
                    context.Links.Add(new Link
                    {
                        LinkUrl = link,
                        UserId = context.Users.Where(u => u.DiscordId == socketUser.Id).FirstOrDefault().UserId
                    });
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    await ReplyAsync($"Error adding <@{socketUser.Id}'s Link>");
                }
                finally
                {
                    await ReplyAsync($"<@{socketUser.Id}>'s Link has been added successfully.");
                }
            }
        }
        #endregion

        [Command("randomlink")]
        public async Task RandomLink()
        {
            using (RileyBotContext context = new RileyBotContext())
            {
                int maxId = context.Links.Select(x => x.LinkId).Max();
                var random = new Random();
                int rng = random.Next(1, maxId);

                Link link = context.Links.Where(x => x.LinkId == rng).FirstOrDefault();

                await ReplyAsync($"{link.LinkUrl}");
            }
        }
    }
}
