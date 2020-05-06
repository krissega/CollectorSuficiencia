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
    public class SubastasController : ControllerBase
    {
        private readonly AplicationDBContext _context;

        public SubastasController(AplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Subastas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subasta>>> GetSubasta()
        {
            return await _context.Subastas.ToListAsync();
        }

        // GET: api/Subastas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subasta>> GetSubasta(int id)
        {
            var subasta = await _context.Subastas.FindAsync(id);

            if (subasta == null)
            {
                return NotFound();
            }

            return subasta;
        }

        // PUT: api/Subastas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubasta(int id, Subasta subasta)
        {
            if (id != subasta.ID)
            {
                return BadRequest();
            }

            _context.Entry(subasta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubastaExists(id))
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

        // POST: api/Subastas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Subasta>> PostSubasta(Subasta subasta)
        {
            _context.Subastas.Add(subasta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubasta", new { id = subasta.ID }, subasta);
        }

        // DELETE: api/Subastas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subasta>> DeleteSubasta(int id)
        {
            var subasta = await _context.Subastas.FindAsync(id);
            if (subasta == null)
            {
                return NotFound();
            }

            _context.Subastas.Remove(subasta);
            await _context.SaveChangesAsync();

            return subasta;
        }

        private bool SubastaExists(int id)
        {
            return _context.Subastas.Any(e => e.ID == id);
        }
    }
}
