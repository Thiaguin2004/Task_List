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
    public class RecursosController : ControllerBase
    {
        private readonly Context _context;

        public RecursosController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recurso>>> GetRecursos()
        {
            return await _context.Recursos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recurso>> GetRecurso(int id)
        {
            var recurso = await _context.Recursos.FindAsync(id);

            if (recurso == null)
            {
                return NotFound();
            }

            return recurso;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecurso(int id, Recurso recurso)
        {
            if (id != recurso.Id)
            {
                return BadRequest();
            }

            _context.Entry(recurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecursoExists(id))
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
        public async Task<ActionResult<Recurso>> PostRecurso(Recurso recurso)
        {
            _context.Recursos.Add(recurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecurso", new { id = recurso.Id }, recurso);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecurso(int id)
        {
            var recurso = await _context.Recursos.FindAsync(id);
            if (recurso == null)
            {
                return NotFound();
            }

            _context.Recursos.Remove(recurso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecursoExists(int id)
        {
            return _context.Recursos.Any(e => e.Id == id);
        }
    }
}
