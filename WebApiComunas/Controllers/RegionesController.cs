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
    public class RegionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Regiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Regiones>>> GetRegiones()
        {
            return await _context.Regiones.ToListAsync();
        }

        // GET: api/Regiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Regiones>> GetRegiones(int id)
        {
            var regiones = await _context.Regiones.FindAsync(id);

            if (regiones == null)
            {
                return NotFound();
            }

            return regiones;
        }

        // PUT: api/Regiones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegiones(int id, Regiones regiones)
        {
            if (id != regiones.Id)
            {
                return BadRequest();
            }

            _context.Entry(regiones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionesExists(id))
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

        // POST: api/Regiones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Regiones>> PostRegiones(Regiones regiones)
        {
            _context.Regiones.Add(regiones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegiones", new { id = regiones.Id }, regiones);
        }

        // DELETE: api/Regiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegiones(int id)
        {
            var regiones = await _context.Regiones.FindAsync(id);
            if (regiones == null)
            {
                return NotFound();
            }

            _context.Regiones.Remove(regiones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegionesExists(int id)
        {
            return _context.Regiones.Any(e => e.Id == id);
        }
    }
}
