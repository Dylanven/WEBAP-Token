using System;
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
using projetAPI2.Methode;
using System.Net.Mail;

namespace projetAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspNetUsersController : ControllerBase
    {
        private readonly PrototypeContext _context;
        private bool repsonse;

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
      /*  [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUser(NewUser newUser)
        {
            if (id != aspNetUser.Id)
            {
                return BadRequest();
            }
            CheckEmail checkEmail = new CheckEmail();
            email = checkEmail.checkEmails(newUser.Email);
            if (email == false)
            {
                return BadRequest("this email is not valid");
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
        }*/

        // POST: api/AspNetUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AspNetUser>> PostAspNetUser(NewUser newUser)
        {
            if (_context.AspNetUsers == null)
            {
                return Problem("Entity set 'PrototypeContext.AspNetUsers'  is null.");
            }

            AspNetUser user = await _context.AspNetUsers.FirstOrDefaultAsync(u => u.UserName == newUser.UserName || u.Email == newUser.Email);
          
            if (user != null)
            {
                return Conflict("User already exists");
            }
            CheckEmail checkEmail = new CheckEmail();
            bool email = checkEmail.checkEmails(newUser.Email);
            if (email == false)
            {
                return BadRequest("this email is not valid");
            }
           
            if (newUser.Password != newUser.ConfirmPassword)
            {
                return BadRequest("Password and Confirm Password must be the same");
            }

            AspNetUser test = ConvertUser.ConvertToDTO(newUser);
            _context.AspNetUsers.Add(test);

            await _context.SaveChangesAsync();
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
            AspNetUser user = await _context.AspNetUsers.FirstOrDefaultAsync(u => u.UserName == log.UserName);

            if (user == null)
            {
                 user = await _context.AspNetUsers.FirstOrDefaultAsync(u => u.Email == log.UserName);
                if (user == null)
                {
                    return NotFound("donnée incorecte");
                }
                
            }
            if (user.LockoutEnabled == true)
            {
                return Unauthorized("your account is locked");
            }
            // Check if password is correct

            if (user.PasswordHash != HashPasword.hashPasword(log.Password))
            {
                return Unauthorized("donnée incorecte");
            }
            if (user.EmailConfirmed == false)
            {
                return Unauthorized("Confirme your mail");
            }
            return Ok();
        }

        // DELETE: api/AspNetUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspNetUser(string username)
        {
            if (_context.AspNetUsers == null)
            {
                return NotFound();
            }
            var aspNetUser = await _context.AspNetUsers.FindAsync(username);
            if (aspNetUser == null)
            {
                return NotFound();
            }
            /*CHECK TOKEN !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!*/
            _context.AspNetUsers.Remove(aspNetUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AspNetUserExists(int id)
        {
            return (_context.AspNetUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}