using System;
using System.Collections.Generic;
using System.Text;

namespace RileyBotDatabaseLibrary.Models
{
    public class Drop
    {
        public int DropId { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int KillCount { get; set; }
        public int UserId { get; set; }
    }
}
