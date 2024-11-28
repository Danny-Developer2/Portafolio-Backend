using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using Api.Data;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HacktheboxController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HacktheboxController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Hackthebox
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hackthebox>>> GetHacktheboxes()
        {
            return await _context.Hacktheboxes.ToListAsync();
        }

        // GET: api/Hackthebox/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Hackthebox>> GetHackthebox(int id)
        {
            var hackthebox = await _context.Hacktheboxes.FindAsync(id);

            if (hackthebox == null)
            {
                return NotFound();
            }

            return hackthebox;
        }

        // POST: api/Hackthebox
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Hackthebox>>> PostHacktheboxes(IEnumerable<Hackthebox> hacktheboxes)
        {
            if (hacktheboxes == null || !hacktheboxes.Any())
            {
                return BadRequest("Debe enviar al menos un objeto.");
            }

            _context.Hacktheboxes.AddRange(hacktheboxes);
            await _context.SaveChangesAsync();

            return Ok(hacktheboxes);
        }


        // PUT: api/Hackthebox/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHackthebox(int id, Hackthebox hackthebox)
        {
            if (id != hackthebox.Id)
            {
                return BadRequest();
            }

            _context.Entry(hackthebox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HacktheboxExists(id))
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

        // DELETE: api/Hackthebox/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHackthebox(int id)
        {
            var hackthebox = await _context.Hacktheboxes.FindAsync(id);

            if (hackthebox == null)
            {
                return NotFound();
            }

            _context.Hacktheboxes.Remove(hackthebox);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HacktheboxExists(int id)
        {
            return _context.Hacktheboxes.Any(e => e.Id == id);
        }

    }
}
