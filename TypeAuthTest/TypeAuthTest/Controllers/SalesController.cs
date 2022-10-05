using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TypeAuthTest.DTOs.SalesDTOs;
using TypeAuthTest.Extentions;
using TypeAuthTest.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TypeAuthTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService salesService;

        public SalesController(ISalesService salesService)
        {
            this.salesService = salesService;
        }

        // GET: api/<SalesController>
        [HttpGet]
        [Authorize(Policy ="Base.Sales")]
        public string Get()
        {
            return "List of sales";
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "Base.Sales")]
        public string Get(int id)
        {
            return "Sales " + id.ToString();
        }

        [HttpGet("Archive")]
        public string GetArchive()
        {
            return salesService.GetArchives();
        }

        // POST api/<SalesController>
        [HttpPost]
        [Authorize(Policy = "Base.Sales.Write")]
        [Authorize(Policy = "Base.Sales.ValidDate")]
        public IActionResult Post([FromBody] SalesDTO salesDTO)
        {
            if (salesDTO.Discount > this.GetAccessTree().Sales.Discount.Value)
                return StatusCode(403, "The discount exceeded you limit");

            return Ok(salesDTO);
        }

        // PUT api/<SalesController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "Base.Sales.Update")]
        [Authorize(Policy = "Base.Sales.ValidDate")]
        public IActionResult Put(int id, [FromBody] SalesDTO salesDTO)
        {
            return Ok(salesDTO);
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "Base.Sales.Delete")]
        public IActionResult Delete(int id)
        {
            return Ok("Delete " + id.ToString());
        }
    }
}
