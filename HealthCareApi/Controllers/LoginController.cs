using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthCareApi.Models;

namespace HealthCareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ModelContext _context;

        public LoginController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Login
        [HttpGet]
        public IEnumerable<HeaUsers> GetHeaUsers()
        {
            return _context.HeaUsers;
        }

        // GET: api/Login/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHeaUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var heaUsers = await _context.HeaUsers.FindAsync(id);

            if (heaUsers == null)
            {
                return NotFound();
            }

            return Ok(heaUsers);
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeaUsers([FromRoute] int id, [FromBody] HeaUsers heaUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != heaUsers.Id)
            {
                return BadRequest();
            }

            _context.Entry(heaUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeaUsersExists(id))
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

        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> PostHeaUsers([FromBody] HeaUsers heaUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HeaUsers.Add(heaUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeaUsers", new { id = heaUsers.Id }, heaUsers);
        }

        // DELETE: api/Login/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeaUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var heaUsers = await _context.HeaUsers.FindAsync(id);
            if (heaUsers == null)
            {
                return NotFound();
            }

            _context.HeaUsers.Remove(heaUsers);
            await _context.SaveChangesAsync();

            return Ok(heaUsers);
        }

        private bool HeaUsersExists(int id)
        {
            return _context.HeaUsers.Any(e => e.Id == id);
        }
    }
}