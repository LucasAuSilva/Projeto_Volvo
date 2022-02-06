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
    public class SalesController : ControllerBase
    {
        private readonly ISaleRepository saleRepository;

        public SalesController(ISaleRepository saleRepository)
        {
            this.saleRepository = saleRepository;
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
        // TODO: Fazer update de venda
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutSale(int id, [FromBody] SaleDto sale)
        // {
        //     if (id != sale.IdSale)
        //     {
        //         return BadRequest();
        //     }

        //     try
        //     {
        //         var updateSale = await saleRepository.UpdateEntity(id, sale.CreateEntity());
        //         return Ok(updateSale);
        //     }
        //     catch (EntityException ex)
        //     {
        //         return NotFound(ex.Message);
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         throw;
        //     }
        // }

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // TODO: Fazer metodo POST para criar venda.
        // [HttpPost]
        // public async Task<ActionResult<Sale>> PostSale(SaleDto saleDto)
        // {
        //     var sale = await saleRepository.AddEntity(saleDto.CreateEntity());
        //     return CreatedAtAction("GetSale", new { id = sale.IdSale }, sale);
        // }

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
