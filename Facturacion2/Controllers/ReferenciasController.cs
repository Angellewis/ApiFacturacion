using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Facturacion2.Models;

namespace Facturacion2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenciasController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ReferenciasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Referencias
        [HttpGet]
        public IEnumerable<Referencia> GetReferencia()
        {
            var referencia = _context.Referencia.Include(a => a.articulo).Include(c => c.clientes).Include(v => v.vendedores);
            return referencia;
        }

        // GET: api/Referencias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReferencia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var referencia = await _context.Referencia.FindAsync(id);

            if (referencia == null)
            {
                return NotFound();
            }

            return Ok(referencia);
        }

        // PUT: api/Referencias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReferencia([FromRoute] int id, [FromBody] Referencia referencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != referencia.Id)
            {
                return BadRequest();
            }

            _context.Entry(referencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferenciaExists(id))
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

        // POST: api/Referencias
        [HttpPost]
        public async Task<IActionResult> PostReferencia([FromBody] Referencia referencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Referencia.Add(referencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReferencia", new { id = referencia.Id }, referencia);
        }

        // DELETE: api/Referencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReferencia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var referencia = await _context.Referencia.FindAsync(id);
            if (referencia == null)
            {
                return NotFound();
            }

            _context.Referencia.Remove(referencia);
            await _context.SaveChangesAsync();

            return Ok(referencia);
        }

        private bool ReferenciaExists(int id)
        {
            return _context.Referencia.Any(e => e.Id == id);
        }
    }
}