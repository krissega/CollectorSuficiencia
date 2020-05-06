using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollectorSuficiencia.Context;
using CollectorSuficiencia.Entities;

namespace CollectorSuficiencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteresController : ControllerBase
    {
        private readonly AplicationDBContext _context;

        public InteresController(AplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Interes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interes>>> GetInteres()
        {
            return await _context.Intereses.ToListAsync();
        }

        // GET: api/Interes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interes>> GetInteres(int id)
        {
            var interes = await _context.Intereses.FindAsync(id);

            if (interes == null)
            {
                return NotFound();
            }

            return interes;
        }

        // PUT: api/Interes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInteres(int id, Interes interes)
        {
            if (id != interes.ID)
            {
                return BadRequest();
            }

            _context.Entry(interes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InteresExists(id))
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

        // POST: api/Interes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Interes>> PostInteres(Interes interes)
        {
            _context.Intereses.Add(interes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInteres", new { id = interes.ID }, interes);
        }

        // DELETE: api/Interes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Interes>> DeleteInteres(int id)
        {
            var interes = await _context.Intereses.FindAsync(id);
            if (interes == null)
            {
                return NotFound();
            }

            _context.Intereses.Remove(interes);
            await _context.SaveChangesAsync();

            return interes;
        }

        private bool InteresExists(int id)
        {
            return _context.Intereses.Any(e => e.ID == id);
        }
    }
}
