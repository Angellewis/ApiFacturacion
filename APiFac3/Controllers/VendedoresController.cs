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
    public class VendedoresController : ControllerBase
    {
        private readonly MyDbContext _context;

        public VendedoresController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Vendedores
        [HttpGet]
        public IEnumerable<Vendedores> GetVendedores()
        {
            return _context.Vendedores;
        }

        // GET: api/Vendedores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendedores([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vendedores = await _context.Vendedores.FindAsync(id);

            if (vendedores == null)
            {
                return NotFound();
            }

            return Ok(vendedores);
        }

        // PUT: api/Vendedores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendedores([FromRoute] int id, [FromBody] Vendedores vendedores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendedores.Id)
            {
                return BadRequest();
            }

            _context.Entry(vendedores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendedoresExists(id))
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

        // POST: api/Vendedores
        [HttpPost]
        public async Task<IActionResult> PostVendedores([FromBody] Vendedores vendedores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Vendedores.Add(vendedores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendedores", new { id = vendedores.Id }, vendedores);
        }

        // DELETE: api/Vendedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendedores([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vendedores = await _context.Vendedores.FindAsync(id);
            if (vendedores == null)
            {
                return NotFound();
            }

            _context.Vendedores.Remove(vendedores);
            await _context.SaveChangesAsync();

            return Ok(vendedores);
        }

        private bool VendedoresExists(int id)
        {
            return _context.Vendedores.Any(e => e.Id == id);
        }
    }
}