﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetAPI2.Models;
using projetAPI2.DTO;
using projetAPI2.Convert;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Prototype.Controllers;

namespace projetAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspNetUsersController : ControllerBase
    {
        private readonly PrototypeContext _context;

        public AspNetUsersController(PrototypeContext context)
        {
            _context = context;
        }
 

        // GET: api/AspNetUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetUser>>> GetAspNetUsers()
        {
          if (_context.AspNetUsers == null)
          {
              return NotFound();
          }
            return await _context.AspNetUsers.ToListAsync();
        }

        // GET: api/AspNetUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetUser>> GetAspNetUser(string id)
        {
          if (_context.AspNetUsers == null)
          {
              return NotFound();
          }
            var aspNetUser = await _context.AspNetUsers.FindAsync(id);

            if (aspNetUser == null)
            {
                return NotFound();
            }

            return aspNetUser;
        }

        // PUT: api/AspNetUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUser(string id, AspNetUser aspNetUser)
        {
            if (id != aspNetUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(aspNetUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUserExists(id))
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

        // POST: api/AspNetUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AspNetUser>> PostAspNetUser(NewUser newUser)
        {
          if (_context.AspNetUsers == null)
          {
              return Problem("Entity set 'PrototypeContext.AspNetUsers'  is null.");
          }
            AspNetUser test = ConvertUser.ConvertToDTO(newUser);
            
            _context.AspNetUsers.Add(test);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetUserExists(test.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            /*send email with mail hepler*/
            MailHelper mail = new MailHelper();
            mail.SendEmail(test.Email, "Confirmation de votre compte", "Bonjour, \n\n Veuillez confirmer votre compte en cliquant sur le lien suivant : \n\n https://localhost:5001/api/AspNetUsers/ConfirmEmail/" + test.Id + "\n\n Cordialement, \n\n L'équipe de la plateforme de gestion de projet");
            return CreatedAtAction("GetAspNetUser", new { id = test.Id }, test);
               
        }
        // POST: api/AspNetUsers LOGIN

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<AspNetUser>> PostLogin(Login log)
        {
            if (log == null)
            {
                return BadRequest("Invalid client request");
            }
            // Get user from database
            var user = await _context.AspNetUsers.FirstOrDefaultAsync(u => u.UserName == log.UserName);
    
            if (user == null)
            {
                return NotFound();
            }
            // Check if password is correct
            Debug.WriteLine("________________________________________" + '\n' + user.PasswordHash +"      "+ log.Password.GetHashCode().ToString());
            if (user.PasswordHash != log.Password.GetHashCode().ToString())
            {
                return Unauthorized("Confirme your mail");
            }
            if (user.EmailConfirmed == false)
            {
                return Unauthorized();
            }
            return Ok();
        }

        // DELETE: api/AspNetUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspNetUser(string id)
        {
            if (_context.AspNetUsers == null)
            {
                return NotFound();
            }
            var aspNetUser = await _context.AspNetUsers.FindAsync(id);
            if (aspNetUser == null)
            {
                return NotFound();
            }

            _context.AspNetUsers.Remove(aspNetUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AspNetUserExists(string id)
        {
            return (_context.AspNetUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}