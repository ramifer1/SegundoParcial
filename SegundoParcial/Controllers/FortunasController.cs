using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegundoParcial.Data;
using SegundoParcial.Modelo;

namespace SegundoParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FortunasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FortunasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Fortunas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fortuna>>> GetFortuna()
        {
            return await _context.Fortuna.ToListAsync();
        }

        // GET: api/Fortunas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fortuna>> GetFortuna(int id)
        {
            var fortuna = await _context.Fortuna.FindAsync(id);

            if (fortuna == null)
            {
                return NotFound();
            }

            return fortuna;
        }

        // PUT: api/Fortunas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFortuna(int id, Fortuna fortuna)
        {
            if (id != fortuna.SuerteId)
            {
                return BadRequest();
            }

            _context.Entry(fortuna).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FortunaExists(id))
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

        // POST: api/Fortunas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fortuna>> PostFortuna(Fortuna fortuna)
        {
            _context.Fortuna.Add(fortuna);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFortuna", new { id = fortuna.SuerteId }, fortuna);
        }

        // DELETE: api/Fortunas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFortuna(int id)
        {
            var fortuna = await _context.Fortuna.FindAsync(id);
            if (fortuna == null)
            {
                return NotFound();
            }

            _context.Fortuna.Remove(fortuna);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FortunaExists(int id)
        {
            return _context.Fortuna.Any(e => e.SuerteId == id);
        }
    }
}
