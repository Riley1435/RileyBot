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
    [Route("[controller]")]
    public class LinkController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Link> Get()
        {
            using (RileyBotContext context = new RileyBotContext())
            {
                var links = context.Links;
                var l = links.ToArray();
                return l;
            }
        }
    }
}