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
    public class MetodoPagoesController : ControllerBase
    {
        private readonly AplicationDBContext _context;

        public MetodoPagoesController(AplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/MetodoPagoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetodoPago>>> GetMetodoPago()
        {
            return await _context.MetodoPago.ToListAsync();
        }

        // GET: api/MetodoPagoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MetodoPago>> GetMetodoPago(int id)
        {
            var metodoPago = await _context.MetodoPago.FindAsync(id);

            if (metodoPago == null)
            {
                return NotFound();
            }

            return metodoPago;
        }

        // PUT: api/MetodoPagoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetodoPago(int id, MetodoPago metodoPago)
        {
            if (id != metodoPago.ID)
            {
                return BadRequest();
            }

            _context.Entry(metodoPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetodoPagoExists(id))
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

        // POST: api/MetodoPagoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MetodoPago>> PostMetodoPago(MetodoPago metodoPago)
        {
            _context.MetodoPago.Add(metodoPago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetodoPago", new { id = metodoPago.ID }, metodoPago);
        }

        // DELETE: api/MetodoPagoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MetodoPago>> DeleteMetodoPago(int id)
        {
            var metodoPago = await _context.MetodoPago.FindAsync(id);
            if (metodoPago == null)
            {
                return NotFound();
            }

            _context.MetodoPago.Remove(metodoPago);
            await _context.SaveChangesAsync();

            return metodoPago;
        }

        private bool MetodoPagoExists(int id)
        {
            return _context.MetodoPago.Any(e => e.ID == id);
        }
    }
}
