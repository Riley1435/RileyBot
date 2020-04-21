using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using RileyBotDatabaseLibrary.Data;
using RileyBotDatabaseLibrary.Models;

namespace RileyBotDataExplorer.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<User> Get()
        {
            using (RileyBotContext context = new RileyBotContext())
            {
                var users = context.Users.ToArray();
                return users;
            }
        }
    }
}