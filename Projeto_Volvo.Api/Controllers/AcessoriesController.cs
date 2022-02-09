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
using Projeto_Volvo.Api.Service;

namespace Projeto_Volvo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcessoriesController : ControllerBase
    {
        private readonly IAcessoryRepository acessoryRepository;
        private readonly IAcessoryService acessoryService;

        public AcessoriesController(IAcessoryRepository acessoryRepository, IAcessoryService acessoryService)
        {
            this.acessoryService = acessoryService;
            this.acessoryRepository = acessoryRepository;
        }

        // GET: api/Acessories
        [HttpGet]
        public async Task<ActionResult<ICollection<Acessory>>> GetAcessories()
        {
            var acessorys = await acessoryRepository.GetAllEntity();
            return Ok(acessorys);
        }

        // GET: api/Acessories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acessory>> GetAcessory(int id)
        {
            try
            {
                var acessory = await acessoryRepository.GetOneEntity(id);
                return acessory;
            }
            catch (EntityException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Acessories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcessory(int id, [FromBody] AcessoryDto acessory)
        {
            if (id != acessory.IdAcessory)
            {
                return BadRequest();
            }

            try
            {
                var updateAcessory = await acessoryRepository.UpdateEntity(id, acessory.CreateEntity());
                return Ok(updateAcessory);
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

        // POST: api/Acessories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Acessory>> PostAcessory(AcessoryDto acessoryDto)
        {
            var newAcessory = await acessoryService.CreateAcessory(acessoryDto);
            var acessory = await acessoryRepository.AddEntity(newAcessory);
            return CreatedAtAction("GetAcessory", new { id = acessory.IdAcessory }, acessory);
        }

        // DELETE: api/Acessories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcessory(int id)
        {
            try
            {
                await acessoryRepository.DeleteEntity(id);
                return Ok();
            }
            catch (EntityException ex)
            {
                throw new EntityException(ex.Message);
            }
        }
    }
}
