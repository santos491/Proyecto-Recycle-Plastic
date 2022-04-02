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
    [Route("api/sitesRecycle")]
    [ApiController]
    public class SitesRecycleController : ControllerBase
    {
        private readonly ProductContext _context;

        public SitesRecycleController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SitesRecycle>>> GetSite()
        {
            return await _context.recycles.ToListAsync();
        }

        // GET: api/Cursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SitesRecycle>> GetSites(int id)
        {
            var cursos = await _context.recycles.FindAsync(id);

            if (cursos == null)
            {
                return NotFound();
            }

            return cursos;
        }

        // PUT: api/Cursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSites(int id, SitesRecycle sitesRecycle)
        {
            if (id != sitesRecycle.Id)
            {
                return BadRequest();
            }

            _context.Entry(sitesRecycle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SitesExists(id))
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
        public async Task<ActionResult<SitesRecycle>> PostSites(SitesRecycle sitesRecycle)
        {
            _context.recycles.Add(sitesRecycle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCursos", new { id = sitesRecycle.Id }, sitesRecycle);
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSites(int id)
        {
            var cursos = await _context.recycles.FindAsync(id);
            if (cursos == null)
            {
                return NotFound();
            }

            _context.recycles.Remove(cursos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SitesExists(int id)
        {
            return _context.recycles.Any(e => e.Id == id);
        }
    }
}
