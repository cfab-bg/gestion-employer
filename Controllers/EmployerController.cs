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
    public class EmployerController : ControllerBase
    {
        private readonly GestionContext _context;

        public EmployerController(GestionContext context)
        {
            _context = context;
        }

        // GET: api/Employer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employer>>> GetEmployers()
        {
          if (_context.Employers == null)
          {
              return NotFound();
          }
            return await _context.Employers.ToListAsync();
        }

        // GET: api/Employer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employer>> GetEmployer(int id)
        {
          if (_context.Employers == null)
          {
              return NotFound();
          }
            var employer = await _context.Employers.FindAsync(id);

            if (employer == null)
            {
                return NotFound();
            }
            var avt = _context.Avantages.Where(e => e.EmployerID == id).ToList();
            employer.Avantages = avt;
            return employer;
        }

        // PUT: api/Employer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployer(int id, Employer employer)
        {
            if (id != employer.EmployerID)
            {
                return BadRequest();
            }

            _context.Entry(employer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerExists(id))
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

        // POST: api/Employer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employer>> PostEmployer(Employer employer)
        {
          if (_context.Employers == null)
          {
              return Problem("Entity set 'GestionContext.Employers'  is null.");
          }
            _context.Employers.Add(employer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployer", new { id = employer.EmployerID }, employer);
        }

        // DELETE: api/Employer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployer(int id)
        {
            if (_context.Employers == null)
            {
                return NotFound();
            }
            var employer = await _context.Employers.FindAsync(id);
            if (employer == null)
            {
                return NotFound();
            }

            _context.Employers.Remove(employer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployerExists(int id)
        {
            return (_context.Employers?.Any(e => e.EmployerID == id)).GetValueOrDefault();
        }
    }
}
