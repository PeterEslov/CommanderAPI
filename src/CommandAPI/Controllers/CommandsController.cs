using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Models;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandContext  _context;
        // Konstructor using Dependency Injection
        public CommandsController(CommandContext context) => _context = context;


        // GET    api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommandItems ()
        {
            return _context.CommandItems;
        }

        //GET:  api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandItem(int id)
        {
            var commandItem = _context.CommandItems.Find(id);

            return commandItem;
        }
    }
}