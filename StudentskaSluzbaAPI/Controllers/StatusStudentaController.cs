using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentskaSluzbaAPI.DAL;
using StudentskaSluzbaAPI.Models;

namespace StudentskaSluzbaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusStudentaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StatusStudentaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StatusStudenta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusStudenta>>> GetStatusStudenta()
        {
          if (_context.StatusStudenta == null)
          {
              return NotFound();
          }
            return await _context.StatusStudenta.ToListAsync();
        }

        // GET: api/StatusStudenta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusStudenta>> GetStatusStudenta(int id)
        {
          if (_context.StatusStudenta == null)
          {
              return NotFound();
          }
            var statusStudenta = await _context.StatusStudenta.FindAsync(id);

            if (statusStudenta == null)
            {
                return NotFound();
            }

            return statusStudenta;
        }

        // PUT: api/StatusStudenta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusStudenta(int id, StatusStudenta statusStudenta)
        {
            if (id != statusStudenta.StatusStudentaId)
            {
                return BadRequest();
            }

            _context.Entry(statusStudenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusStudentaExists(id))
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

        // POST: api/StatusStudenta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusStudenta>> PostStatusStudenta(StatusStudenta statusStudenta)
        {
          if (_context.StatusStudenta == null)
          {
              return Problem("Entity set 'ApplicationDbContext.StatusStudenta'  is null.");
          }
            _context.StatusStudenta.Add(statusStudenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusStudenta", new { id = statusStudenta.StatusStudentaId }, statusStudenta);
        }

        // DELETE: api/StatusStudenta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusStudenta(int id)
        {
            if (_context.StatusStudenta == null)
            {
                return NotFound();
            }
            var statusStudenta = await _context.StatusStudenta.FindAsync(id);
            if (statusStudenta == null)
            {
                return NotFound();
            }

            _context.StatusStudenta.Remove(statusStudenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusStudentaExists(int id)
        {
            return (_context.StatusStudenta?.Any(e => e.StatusStudentaId == id)).GetValueOrDefault();
        }
    }
}
