#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Volvo.Api.Contracts;
using Projeto_Volvo.Api.Exceptions;
using Projeto_Volvo.Api.Models;
using Projeto_Volvo.Api.Models.Dto;

namespace Projeto_Volvo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealershipsController : ControllerBase
    {
        private readonly IDealershipRepository dealershipRepository;

        public DealershipsController(IDealershipRepository dealershipRepository)
        {
            this.dealershipRepository = dealershipRepository;
        }

        // GET: api/Dealerships
        [HttpGet]
        public async Task<ActionResult<ICollection<Dealership>>> GetDealerships()
        {
            var dealership = await dealershipRepository.GetAllEntity();
            return Ok(dealership);
        }

        // GET: api/Dealerships/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dealership>> GetDealership(int id)
        {
            try
            {
                var dealership = await dealershipRepository.GetOneEntity(id);
                return dealership;
            }
            catch (EntityException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Dealerships/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDealership(int id, [FromBody] DealershipDto dealership)
        {
            if (id != dealership.IdDealership)
            {
                return BadRequest();
            }

            try
            {
                var updateDealership = await dealershipRepository.UpdateEntity(id, dealership.CreateEntity());
                return Ok(updateDealership);
            }
            catch (EntityException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        // POST: api/Dealerships
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dealership>> PostDealership(DealershipDto dealershipDto)
        {
            var dealership = await dealershipRepository.AddEntity(dealershipDto.CreateEntity());
            return CreatedAtAction("GetDealership", new { id = dealership.IdDealership }, dealership);
        }

        // DELETE: api/Dealerships/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDealership(int id)
        {
            try
            {
                await dealershipRepository.DeleteEntity(id);
                return Ok();
            }
            catch (EntityException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
