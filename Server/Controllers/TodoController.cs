using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Server;
using Shared;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly DatabaseAppContext _context;
        private readonly IHubContext<TodoHub> _hubContext;

        public TodoController(DatabaseAppContext context, IHubContext<TodoHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoEntry>>> Get()
        {
            return await _context.TodoEntries.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post(TodoEntry item)
        {
            _context.TodoEntries.Add(item);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("RefreshTasks");
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.TodoEntries.FindAsync(id);
            if (item == null) return NotFound();
            _context.TodoEntries.Remove(item);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("RefreshTasks");
            return Ok();
        }
    }
}
