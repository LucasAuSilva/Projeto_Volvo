#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Volvo.Api.Models;

namespace Projeto_Volvo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcessoriesController : ControllerBase
    {
        private readonly VolvoContext _context;

        public AcessoriesController(VolvoContext context)
        {
            _context = context;
        }

        // GET: api/Acessories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acessory>>> GetAcessories()
        {
            return await _context.Acessories.ToListAsync();
        }

        // GET: api/Acessories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acessory>> GetAcessory(int id)
        {
            var acessory = await _context.Acessories.FindAsync(id);

            if (acessory == null)
            {
                return NotFound();
            }

            return acessory;
        }

        // PUT: api/Acessories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcessory(int id, Acessory acessory)
        {
            if (id != acessory.IdAcessory)
            {
                return BadRequest();
            }

            _context.Entry(acessory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcessoryExists(id))
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

        // POST: api/Acessories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Acessory>> PostAcessory(Acessory acessory)
        {
            _context.Acessories.Add(acessory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcessory", new { id = acessory.IdAcessory }, acessory);
        }

        // DELETE: api/Acessories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcessory(int id)
        {
            var acessory = await _context.Acessories.FindAsync(id);
            if (acessory == null)
            {
                return NotFound();
            }

            _context.Acessories.Remove(acessory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcessoryExists(int id)
        {
            return _context.Acessories.Any(e => e.IdAcessory == id);
        }
    }
}
