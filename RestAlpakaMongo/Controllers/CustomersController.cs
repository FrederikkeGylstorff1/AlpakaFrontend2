using Microsoft.AspNetCore.Mvc;
using RestAlpakaMongo.Models;
using RestAlpakaMongo.Services;

namespace RestAlpakaMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
       private readonly CustomersService _customersService;

        public CustomersController(CustomersService customersService)
        {
            _customersService = customersService;  
        }


        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetAllCustomers()
        {
            var Customers = await _customersService.GetAllAsync();
            return Ok(Customers);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomers(string id)
        {
            var customers = await _customersService.GetByIdAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customers>> CreateCustomers(Customers c)
        {
            await _customersService.CreateAsync(c);
            return CreatedAtAction("GetCustomers", new { id = c.Id }, c);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomers(string id, Customers c)
        {
            if (id != c.Id)
            {
                return BadRequest();
            }
            await _customersService.UpdateAsync(id, c);
            return NoContent();
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomers(string id)
        {
            var customer = await _customersService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _customersService.DeleteAsync(id);
            return NoContent();
        }
    }
}
