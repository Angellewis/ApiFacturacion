using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APiFac3.Models;
using Microsoft.AspNetCore.Cors;

namespace APiFac3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("permitir")]
    public class DetallesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public DetallesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Detalles
        [HttpGet]
        public IEnumerable<Detalle> GetDetalles()
        {
            return _context.Detalles
                .Include(a => a.articulos)
                .Include(f => f.factura)
                    .ThenInclude(v => v.vendedores)
                .Include(f => f.factura)
                    .ThenInclude(c => c.clientes);
        }

        // GET: api/Detalles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetalle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detalle =  _context.Detalles
                .Include(a => a.articulos).Where(x=>x.factura.Id == id);

            if (detalle == null)
            {
                return NotFound();
            }

            return Ok(detalle);
        }

        // PUT: api/Detalles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalle([FromRoute] int id, [FromBody] Detalle detalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detalle.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleExists(id))
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

        // POST: api/Detalles
        [HttpPost]
        public async Task<IActionResult> PostDetalle([FromBody] Detalle detalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Detalles.Add(detalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalle", new { id = detalle.Id }, detalle);
        }

        // DELETE: api/Detalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detalle = await _context.Detalles.FindAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }

            _context.Detalles.Remove(detalle);
            await _context.SaveChangesAsync();

            return Ok(detalle);
        }

        private bool DetalleExists(int id)
        {
            return _context.Detalles.Any(e => e.Id == id);
        }
    }
}