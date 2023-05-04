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
    public class StatesEventsController : ControllerBase
    {
        private readonly PrototypeContext _context;

        public StatesEventsController(PrototypeContext context)
        {
            _context = context;
        }

        // GET: api/StatesEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatesEvent>>> GetStatesEvents()
        {
          if (_context.StatesEvents == null)
          {
              return NotFound();
          }
            return await _context.StatesEvents.ToListAsync();
        }

        // GET: api/StatesEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatesEvent>> GetStatesEvent(int id)
        {
          if (_context.StatesEvents == null)
          {
              return NotFound();
          }
            var statesEvent = await _context.StatesEvents.FindAsync(id);

            if (statesEvent == null)
            {
                return NotFound();
            }

            return statesEvent;
        }

        // PUT: api/StatesEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatesEvent(int id, StatesEvent statesEvent)
        {
            if (id != statesEvent.IdStatesEvent)
            {
                return BadRequest();
            }

            _context.Entry(statesEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatesEventExists(id))
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

        // POST: api/StatesEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatesEvent>> PostStatesEvent(StatesEventDTO statesEvent)
        {
          if (_context.StatesEvents == null)
          {
              return Problem("Entity set 'PrototypeContext.StatesEvents'  is null.");

          }

            var newStatesEvent = new StatesEvent
            {
                StaEvName = statesEvent.StaEvName,
            };
            _context.StatesEvents.Add(newStatesEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatesEvent", new { id = newStatesEvent.IdStatesEvent }, newStatesEvent);
        }

        // DELETE: api/StatesEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatesEvent(int id)
        {
            if (_context.StatesEvents == null)
            {
                return NotFound();
            }
            var statesEvent = await _context.StatesEvents.FindAsync(id);
            if (statesEvent == null)
            {
                return NotFound();
            }

            _context.StatesEvents.Remove(statesEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatesEventExists(int id)
        {
            return (_context.StatesEvents?.Any(e => e.IdStatesEvent == id)).GetValueOrDefault();
        }
    }
}
