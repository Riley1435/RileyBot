using System;
using System.Collections.Generic;
using System.Text;

namespace RileyBotDatabaseLibrary.Models
{
    public class Link
    {
        public int LinkId { get; set; }
        public string LinkUrl { get; set; }

        public int UserId { get; set; }
    }
}
