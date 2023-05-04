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
    public class StatesTasksController : ControllerBase
    {
        private readonly PrototypeContext _context;

        public StatesTasksController(PrototypeContext context)
        {
            _context = context;
        }

        // GET: api/StatesTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatesTask>>> GetStatesTasks()
        {
          if (_context.StatesTasks == null)
          {
              return NotFound();
          }
            return await _context.StatesTasks.ToListAsync();
        }

        // GET: api/StatesTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatesTask>> GetStatesTask(int id)
        {
          if (_context.StatesTasks == null)
          {
              return NotFound();
          }
            var statesTask = await _context.StatesTasks.FindAsync(id);

            if (statesTask == null)
            {
                return NotFound();
            }

            return statesTask;
        }

        // PUT: api/StatesTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatesTask(int id, StatesTask statesTask)
        {
            if (id != statesTask.IdStatesTask)
            {
                return BadRequest();
            }

            _context.Entry(statesTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatesTaskExists(id))
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

        // POST: api/StatesTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatesTask>> PostStatesTask(StatesTaskDTO statesTask)
        {
          if (_context.StatesTasks == null)
          {
              return Problem("Entity set 'PrototypeContext.StatesTasks'  is null.");
          }

            var newSatesTask = new StatesTask
            {
                StaTaName = statesTask.StaTaName,
            };
            _context.StatesTasks.Add(newSatesTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatesTask", new { id = newSatesTask.IdStatesTask }, newSatesTask);
        }

        // DELETE: api/StatesTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatesTask(int id)
        {
            if (_context.StatesTasks == null)
            {
                return NotFound();
            }
            var statesTask = await _context.StatesTasks.FindAsync(id);
            if (statesTask == null)
            {
                return NotFound();
            }

            _context.StatesTasks.Remove(statesTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatesTaskExists(int id)
        {
            return (_context.StatesTasks?.Any(e => e.IdStatesTask == id)).GetValueOrDefault();
        }
    }
}
