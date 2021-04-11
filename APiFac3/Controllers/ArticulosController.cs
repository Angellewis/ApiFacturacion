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
    public class ArticulosController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ArticulosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Articulos
        [HttpGet]
        public IEnumerable<Articulos> GetArticulos()
        {
            return _context.Articulos;
        }

        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticulos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var articulos = await _context.Articulos.FindAsync(id);

            if (articulos == null)
            {
                return NotFound();
            }

            return Ok(articulos);
        }

        // PUT: api/Articulos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulos([FromRoute] int id, [FromBody] Articulos articulos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != articulos.Id)
            {
                return BadRequest();
            }

            _context.Entry(articulos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticulosExists(id))
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

        // POST: api/Articulos
        [HttpPost]
        public async Task<IActionResult> PostArticulos([FromBody] Articulos articulos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Articulos.Add(articulos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticulos", new { id = articulos.Id }, articulos);
        }

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var articulos = await _context.Articulos.FindAsync(id);
            if (articulos == null)
            {
                return NotFound();
            }

            _context.Articulos.Remove(articulos);
            await _context.SaveChangesAsync();

            return Ok(articulos);
        }

        private bool ArticulosExists(int id)
        {
            return _context.Articulos.Any(e => e.Id == id);
        }
    }
}