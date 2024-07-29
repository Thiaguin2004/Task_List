using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_List.Server.Contexto;
using Task_List.Server.Models;

namespace Task_List.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TiposController : ControllerBase
    {
        private readonly Context _context;

        public TiposController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo>>> GetTipos()
        {
            return await _context.Tipos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tipo>> GetTipo(int id)
        {
            var tipo = await _context.Tipos.FindAsync(id);

            if (tipo == null)
            {
                return NotFound();
            }

            return tipo;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipo(int id, Tipo tipo)
        {
            if (id != tipo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Tipo>> PostTipo(Tipo tipo)
        {
            _context.Tipos.Add(tipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipo", new { id = tipo.Id }, tipo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipo(int id)
        {
            var tipo = await _context.Tipos.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }

            _context.Tipos.Remove(tipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoExists(int id)
        {
            return _context.Tipos.Any(e => e.Id == id);
        }
    }
}
