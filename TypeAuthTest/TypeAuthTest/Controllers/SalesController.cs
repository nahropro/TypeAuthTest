using Microsoft.AspNetCore.Mvc;
using TypeAuthTest.DTOs.SalesDTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TypeAuthTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        // GET: api/<SalesController>
        [HttpGet]
        public string Get()
        {
            return "List of sales";
        }

        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Sales " + id.ToString();
        }

        // POST api/<SalesController>
        [HttpPost]
        public IActionResult Post([FromBody] SalesDTO salesDTO)
        {
            return Ok(salesDTO);
        }

        // PUT api/<SalesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SalesDTO salesDTO)
        {
            return Ok(salesDTO);
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("Delete " + id.ToString());
        }
    }
}
