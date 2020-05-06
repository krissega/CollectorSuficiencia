﻿using System;
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
    public class OrdenComprasController : ControllerBase
    {
        private readonly AplicationDBContext _context;

        public OrdenComprasController(AplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/OrdenCompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenCompra>>> GetOrdenCompra()
        {
            return await _context.OrdenCompras.ToListAsync();
        }

        // GET: api/OrdenCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenCompra>> GetOrdenCompra(int id)
        {
            var ordenCompra = await _context.OrdenCompras.FindAsync(id);

            if (ordenCompra == null)
            {
                return NotFound();
            }

            return ordenCompra;
        }

        // PUT: api/OrdenCompras/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenCompra(int id, OrdenCompra ordenCompra)
        {
            if (id != ordenCompra.ID)
            {
                return BadRequest();
            }

            _context.Entry(ordenCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenCompraExists(id))
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

        // POST: api/OrdenCompras
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrdenCompra>> PostOrdenCompra(OrdenCompra ordenCompra)
        {
            _context.OrdenCompras.Add(ordenCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenCompra", new { id = ordenCompra.ID }, ordenCompra);
        }

        // DELETE: api/OrdenCompras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdenCompra>> DeleteOrdenCompra(int id)
        {
            var ordenCompra = await _context.OrdenCompras.FindAsync(id);
            if (ordenCompra == null)
            {
                return NotFound();
            }

            _context.OrdenCompras.Remove(ordenCompra);
            await _context.SaveChangesAsync();

            return ordenCompra;
        }

        private bool OrdenCompraExists(int id)
        {
            return _context.OrdenCompras.Any(e => e.ID == id);
        }
    }
}
