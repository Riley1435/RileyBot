using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RileyBotDatabaseLibrary.Data;
using RileyBotDatabaseLibrary.Models;

namespace RileyBotDataExplorer.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DropController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Drop> Get()
        {
            using (RileyBotContext context = new RileyBotContext())
            {
                var drops = context.Drops;
                return drops.ToArray();
            }
        }
    }
}