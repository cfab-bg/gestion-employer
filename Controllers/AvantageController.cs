using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffApi.Models;

namespace StaffApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvantageController : ControllerBase
    {
        private readonly GestionContext _context;

        public AvantageController(GestionContext context)
        {
            _context = context;
        }

        // GET: api/Avantage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avantage>>> GetAvantages()
        {
          if (_context.Avantages == null)
          {
              return NotFound();
          }
            return await _context.Avantages.ToListAsync();
        }

        // GET: api/Avantage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Avantage>> GetAvantage(int id)
        {
          if (_context.Avantages == null)
          {
              return NotFound();
          }
            var avantage = await _context.Avantages.FindAsync(id);

            if (avantage == null)
            {
                return NotFound();
            }

            return avantage;
        }

        // PUT: api/Avantage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvantage(int id, Avantage avantage)
        {
            if (id != avantage.AvantageID)
            {
                return BadRequest();
            }

            _context.Entry(avantage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvantageExists(id))
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

        // POST: api/Avantage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Avantage>> PostAvantage(Avantage avantage)
        {
          if (_context.Avantages == null)
          {
              return Problem("Entity set 'GestionContext.Avantages'  is null.");
          }
            _context.Avantages.Add(avantage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvantage", new { id = avantage.AvantageID }, avantage);
        }

        // DELETE: api/Avantage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvantage(int id)
        {
            if (_context.Avantages == null)
            {
                return NotFound();
            }
            var avantage = await _context.Avantages.FindAsync(id);
            if (avantage == null)
            {
                return NotFound();
            }

            _context.Avantages.Remove(avantage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvantageExists(int id)
        {
            return (_context.Avantages?.Any(e => e.AvantageID == id)).GetValueOrDefault();
        }
    }
}
