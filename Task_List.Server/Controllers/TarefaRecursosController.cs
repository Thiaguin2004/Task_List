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
    public class TarefaRecursosController : ControllerBase
    {
        private readonly Context _context;

        public TarefaRecursosController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaRecursos>>> GetTarefaRecursos()
        {
            return await _context.TarefaRecursos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaRecursos>> GetTarefaRecursos(int id)
        {
            var tarefaRecursos = await _context.TarefaRecursos.FindAsync(id);

            if (tarefaRecursos == null)
            {
                return NotFound();
            }

            return tarefaRecursos;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefaRecursos(int id, TarefaRecursos tarefaRecursos)
        {
            if (id != tarefaRecursos.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarefaRecursos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaRecursosExists(id))
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
        public async Task<ActionResult<TarefaRecursos>> PostTarefaRecursos(TarefaRecursos tarefaRecursos)
        {
            _context.TarefaRecursos.Add(tarefaRecursos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarefaRecursos", new { id = tarefaRecursos.Id }, tarefaRecursos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefaRecursos(int id)
        {
            var tarefaRecursos = await _context.TarefaRecursos.FindAsync(id);
            if (tarefaRecursos == null)
            {
                return NotFound();
            }

            _context.TarefaRecursos.Remove(tarefaRecursos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarefaRecursosExists(int id)
        {
            return _context.TarefaRecursos.Any(e => e.Id == id);
        }
    }
}
