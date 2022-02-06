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
    public class BuyersController : ControllerBase
    {
        private readonly IBuyerRepository buyerRepository;

        public BuyersController(IBuyerRepository buyerRepository)
        {
            this.buyerRepository = buyerRepository;
        }

        // GET: api/Buyers
        [HttpGet]
        public async Task<ActionResult<ICollection<Buyer>>> GetBuyers()
        {
            var buyers = await buyerRepository.GetAllEntity();
            return Ok(buyers);
        }

        // GET: api/Buyers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Buyer>> GetBuyer(int id)
        {
            try
            {
                var buyer = await buyerRepository.GetOneEntity(id);
                return buyer;
            }
            catch (EntityException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Buyers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuyer(int id, [FromBody] BuyerDto buyer)
        {
            if (id != buyer.IdBuyer)
            {
                return BadRequest();
            }

            try
            {
                var updateBuyer = await buyerRepository.UpdateEntity(id, buyer.CreateEntity());
                return Ok(updateBuyer);
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

        // POST: api/Buyers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Buyer>> PostBuyer(BuyerDto buyerDto)
        {
            var buyer = await buyerRepository.AddEntity(buyerDto.CreateEntity());
            return CreatedAtAction("GetBuyer", new { id = buyer.IdBuyer }, buyer);
        }

        // DELETE: api/Buyers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuyer(int id)
        {
            try
            {
                await buyerRepository.DeleteEntity(id);
                return Ok();
            }
            catch (EntityException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
