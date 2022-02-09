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
    public class SalesController : ControllerBase
    {
        private readonly ISaleRepository saleRepository;
        private readonly ISaleService saleService;

        public SalesController(ISaleRepository saleRepository, ISaleService saleService)
        {
            this.saleRepository = saleRepository;
            this.saleService = saleService;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<ICollection<Sale>>> GetSales()
        {
            var sale = await saleRepository.GetAllEntity();
            return Ok(sale);
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            try
            {
                var sale = await saleRepository.GetOneEntity(id);
                return sale;
            }
            catch (EntityException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(int id, [FromBody] SaleDto saleDto)
        {
            if (id != saleDto.IdSale)
            {
                return BadRequest();
            }

            try
            {
                var sale = await saleService.CreateSale(saleDto);
                var updateSale = await saleRepository.UpdateEntity(id, sale);
                return Ok(updateSale);
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

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(SaleDto saleDto)
        {
            var newSale = await saleService.CreateSale(saleDto);
            var sale = await saleRepository.AddEntity(newSale);
            return CreatedAtAction("GetSale", new { id = sale.IdSale }, sale);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            try
            {
                await saleRepository.DeleteEntity(id);
                return Ok();
            }
            catch (EntityException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
