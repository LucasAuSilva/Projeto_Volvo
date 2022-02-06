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
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerRepository ownerRepository;

        public OwnersController(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
        }

        // GET: api/Owners
        [HttpGet]
        public async Task<ActionResult<ICollection<Owner>>> GetOwners()
        {
            var owner = await ownerRepository.GetAllEntity();
            return Ok(owner);
        }

        // GET: api/Owners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetOwner(int id)
        {
            try
            {
                var owner = await ownerRepository.GetOneEntity(id);
                return owner;
            }
            catch (EntityException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Owners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner(int id, [FromBody] OwnerDto owner)
        {
            if (id != owner.IdOwner)
            {
                return BadRequest();
            }

            try
            {
                var updateOwner = await ownerRepository.UpdateEntity(id, owner.CreateEntity());
                return Ok(updateOwner);
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

        // POST: api/Owners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Owner>> PostOwner(OwnerDto ownerDto)
        {
            var owner = await ownerRepository.AddEntity(ownerDto.CreateEntity());
            return CreatedAtAction("GetOwner", new { id = owner.IdOwner }, owner);
        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            try
            {
                await ownerRepository.DeleteEntity(id);
                return Ok();
            }
            catch (EntityException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
