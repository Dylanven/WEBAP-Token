﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetAPI2.Convert;
using projetAPI2.DTO;
using projetAPI2.Models;

namespace projetAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly PrototypeContext _context;


        public PlacesController(PrototypeContext context)
        {
            _context = context;
        }

        // GET: api/Places
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlaces()
        {
          if (_context.Places == null)
          {
              return NotFound();
          }
            return await _context.Places.ToListAsync();
        }

        // GET: api/Places/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> GetPlace(int id)
        {
          if (_context.Places == null)
          {
              return NotFound();
          }
            var place = await _context.Places.FindAsync(id);

            if (place == null)
            {
                return NotFound();
            }

            return place;
        }

        // PUT: api/Places/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlace(int id, Place place)
        {
            if (id != place.IdPlace)
            {
                return BadRequest();
            }

            _context.Entry(place).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceExists(id))
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

        // POST: api/Places
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Place>> PostPlace(PlaceDTO place)
        {
            if (_context.Places == null)
            {
                return Problem("Entity set 'PrototypeContext.Places'  is null.");
            }
            Country name = await _context.Countries.FirstOrDefaultAsync(c => c.CouName == place.CouName);
            if (name == null)
            {
                return NotFound("Country not found.");
            }
            Debug.WriteLine("---------------------------------------Country found: " + name.CouName);
            int idcountry = name.IdCountry;
            Debug.WriteLine("---------------------------------------Country found: " + idcountry);
            Place newplace = ConvertPlace.ConvertPlaces(place, idcountry);
            _context.Places.Add(newplace);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPlace", new { id = newplace.IdPlace }, newplace);

        }

        // DELETE: api/Places/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlace(int id)
        {
            if (_context.Places == null)
            {
                return NotFound();
            }
            var place = await _context.Places.FindAsync(id);
            if (place == null)
            {
                return NotFound();
            }

            _context.Places.Remove(place);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlaceExists(int id)
        {
            return (_context.Places?.Any(e => e.IdPlace == id)).GetValueOrDefault();
        }
    }
}
