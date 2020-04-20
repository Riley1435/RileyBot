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
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<User> Get()
        {
            using (RileyBotContext context = new RileyBotContext())
            {
                var users = context.Users;
                var test = users.ToArray();
                return test;
            }
        }
    }
}