﻿using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("points")]
        public async Task Points()
        {
            await ReplyAsync("You have 10 points");
        }

        [Command("user")]
        public async Task UserInfo(SocketUser user = null)
        {
            var userInfo = user ?? Context.Client.CurrentUser;
            await ReplyAsync($"{userInfo.Username} - {userInfo.Discriminator}");
        }

        [Command("help")]
        public async Task Help()
        {
            await ReplyAsync("show help message");
        }

        
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

        [Command("cleaned")]
        public async Task CleanedAsync(SocketUser user = null)
        {
            if (user != null)
            {
                await ReplyAsync($"<@{user.Id}> has just been cleaned.");
            }
            else
            {
                // clean members
                await ReplyAsync("Please ping to clean.");
            }
        }
    }
}
