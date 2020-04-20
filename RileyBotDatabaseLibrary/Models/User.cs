using System;
using System.Collections.Generic;
using System.Text;

namespace RileyBotDatabaseLibrary.Models
{
    public class User
    {
        public int UserId { get; set; }
        public ulong DiscordId { get; set; }
        public DateTime Added { get; set; }
        public List<Drop> Drops { get; } = new List<Drop>();
    }
}
