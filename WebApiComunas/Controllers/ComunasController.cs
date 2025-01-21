using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiComunas.Context;
using WebApiComunas.Models;

namespace WebApiComunas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComunasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComunasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Comunas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comunas>>> GetComunas()
        {
            return await _context.Comunas.ToListAsync();
        }

        // GET: api/Comunas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comunas>> GetComunas(int id)
        {
            var comunas = await _context.Comunas.FindAsync(id);

            if (comunas == null)
            {
                return NotFound();
            }

            return comunas;
        }

        // PUT: api/Comunas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComunas(int id, Comunas comunas)
        {
            if (id != comunas.Id)
            {
                return BadRequest();
            }

            _context.Entry(comunas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComunasExists(id))
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

        // POST: api/Comunas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comunas>> PostComunas(Comunas comunas)
        {
            _context.Comunas.Add(comunas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComunas", new { id = comunas.Id }, comunas);
        }

        // DELETE: api/Comunas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComunas(int id)
        {
            var comunas = await _context.Comunas.FindAsync(id);
            if (comunas == null)
            {
                return NotFound();
            }

            _context.Comunas.Remove(comunas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComunasExists(int id)
        {
            return _context.Comunas.Any(e => e.Id == id);
        }
    }
}
