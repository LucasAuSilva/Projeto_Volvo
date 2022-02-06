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
    public class DealershipsController : ControllerBase
    {
        private readonly VolvoContext _context;

        public DealershipsController(VolvoContext context)
        {
            _context = context;
        }

        // GET: api/Dealerships
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dealership>>> GetDealerships()
        {
            return await _context.Dealerships.ToListAsync();
        }

        // GET: api/Dealerships/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dealership>> GetDealership(int id)
        {
            var dealership = await _context.Dealerships.FindAsync(id);

            if (dealership == null)
            {
                return NotFound();
            }

            return dealership;
        }

        // PUT: api/Dealerships/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDealership(int id, Dealership dealership)
        {
            if (id != dealership.IdDealership)
            {
                return BadRequest();
            }

            _context.Entry(dealership).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealershipExists(id))
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

        // POST: api/Dealerships
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dealership>> PostDealership(Dealership dealership)
        {
            _context.Dealerships.Add(dealership);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDealership", new { id = dealership.IdDealership }, dealership);
        }

        // DELETE: api/Dealerships/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDealership(int id)
        {
            var dealership = await _context.Dealerships.FindAsync(id);
            if (dealership == null)
            {
                return NotFound();
            }

            _context.Dealerships.Remove(dealership);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DealershipExists(int id)
        {
            return _context.Dealerships.Any(e => e.IdDealership == id);
        }
    }
}
