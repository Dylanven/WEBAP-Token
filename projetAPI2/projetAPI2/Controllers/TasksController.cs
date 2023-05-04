using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetAPI2.Models;
using projetAPI2.DTO;

namespace projetAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly PrototypeContext _context;

        public TasksController(PrototypeContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetTasks()
        {
          if (_context.Tasks == null)
          {
              return NotFound();
          }
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Task>> GetTask(int id)
        {
          if (_context.Tasks == null)
          {
              return NotFound();
          }
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, Models.Task task)
        {
            if (id != task.IdTask)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.Task>> PostTask(TaskDTO task)
        {
          if (_context.Tasks == null)
          {
              return Problem("Entity set 'PrototypeContext.Tasks'  is null.");
          }

            var newTask = new Models.Task
            {
                TasTitle = task.TasTitle,
                TasDescription = task.TasDescription,
                TasStartDate = task.TasStartDate,
                TasEndDate = task.TasEndDate,
                IdStatesTask = task.IdStatesTask,
                IdEvent = task.IdEvent

            };

            if (_context.Tasks.Any(c => c.TasTitle == newTask.TasTitle))
            {
                return BadRequest("L'événement existe déjà");
            }
            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = newTask.IdTask }, newTask);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            if (_context.Tasks == null)
            {
                return NotFound();
            }
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return (_context.Tasks?.Any(e => e.IdTask == id)).GetValueOrDefault();
        }
    }
}
