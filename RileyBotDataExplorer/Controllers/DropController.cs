using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RileyBotDatabaseLibrary.Data;
using RileyBotDatabaseLibrary.Models;

namespace RileyBotDataExplorer.Controllers
{
    public class DropController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Drop> Get()
        {
            using (RileyBotContext context = new RileyBotContext())
            {
                var drops = context.Drops;
                return drops;
            }
        }
    }
}