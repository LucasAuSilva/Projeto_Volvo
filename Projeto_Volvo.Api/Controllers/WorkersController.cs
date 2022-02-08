﻿#nullable disable
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
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerRepository workerRepository;

        public WorkersController(IWorkerRepository workerRepository)
        {
            this.workerRepository = workerRepository;
        }

        // GET: api/Workers
        [HttpGet]
        public async Task<ActionResult<ICollection<Worker>>> GetWorkers()
        {
            var worker = await workerRepository.GetAllEntity();
            return Ok(worker);
        }

        // GET: api/Workers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Worker>> GetWorker(int id)
        {
            try
            {
                var worker = await workerRepository.GetOneEntity(id);
                return worker;
            }
            catch (Exception ex)
            {
                throw new Exception("Entidade não encontrada.");
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Workers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorker(int id, [FromBody] WorkerDto worker)
        {
            if (id != worker.IdWorker)
            {
                return BadRequest();
            }

            try
            {
                var updateWorker = await workerRepository.UpdateEntity(id, worker.CreateEntity());
                return Ok(updateWorker);
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

        // POST: api/Workers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Worker>> PostWorker(WorkerDto workerDto)
        {
            var worker = await workerRepository.AddEntity(workerDto.CreateEntity());
            return CreatedAtAction("GetWorker", new { id = worker.IdWorker }, worker);
        }

        // DELETE: api/Workers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker(int id)
        {
            try
            {
                await workerRepository.DeleteEntity(id);
                return Ok();
            }
            catch (EntityException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
