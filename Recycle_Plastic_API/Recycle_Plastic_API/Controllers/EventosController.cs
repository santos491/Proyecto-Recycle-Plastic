using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Recycle_Plastic_API.Context;
using Entities.Models;

namespace _01_NewReciclaje_API.Controllers
{
    [Route("api/eventos")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly ProductContext _context;

        public EventosController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Events>>> GetEvent()
        {
            return await _context.events.ToListAsync();
        }

        // GET: api/Cursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Events>> GetEvents(int id)
        {
            var cursos = await _context.events.FindAsync(id);

            if (cursos == null)
            {
                return NotFound();
            }

            return cursos;
        }

        // PUT: api/Cursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvents(int id, Events events)
        {
            if (id != events.Id)
            {
                return BadRequest();
            }

            _context.Entry(events).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Cursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Events>> PostEvents(Events events)
        {
            _context.events.Add(events);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCursos", new { id = events.Id }, events);
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvents(int id)
        {
            var cursos = await _context.events.FindAsync(id);
            if (cursos == null)
            {
                return NotFound();
            }

            _context.events.Remove(cursos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(int id)
        {
            return _context.events.Any(e => e.Id == id);
        }
    }
}
