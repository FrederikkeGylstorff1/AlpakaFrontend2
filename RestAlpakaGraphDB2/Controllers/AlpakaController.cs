using Microsoft.AspNetCore.Mvc;
using RestAlpaka.Model;
using WebApplication2.Services;

namespace WebApplication2.Controllers

{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class AlpakaController : ControllerBase
    {
        private readonly AlpakaService _alpakaService;

        public AlpakaController(AlpakaService alpakaService)
        {
            _alpakaService = alpakaService;
        }

        // GET: api/Alpaka
        [HttpGet]
        [Route("api/Alpaka")] 
        public async Task<ActionResult<IEnumerable<Alpaka>>> Get()
        {
            var alpakas = await _alpakaService.GetAllAsync();
            return Ok(alpakas);
        }

        // GET: api/Alpaka/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alpaka>> Get(Guid id)
        {
            var alpaka = await _alpakaService.GetByIdAsync(id);
            if (alpaka == null)
            {
                return NotFound();
            }
            return alpaka;
        }

        [HttpPost]
        [Route("api/Alpaka")] // Add a route here
        public async Task<ActionResult<Alpaka>> Post(Alpaka alpaka)
        {
            await _alpakaService.CreateAsync(alpaka);
            return CreatedAtAction(nameof(Get), new { id = alpaka.Id }, alpaka);
        }


        // PUT: api/Alpaka/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Alpaka alpaka)
        {
            if (id != alpaka.Id)
            {
                return BadRequest();
            }
            await _alpakaService.UpdateAsync(id, alpaka);
            return NoContent();
        }

        // DELETE: api/Alpaka/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _alpakaService.DeleteAsync(id);
    
            var alpaka = await _alpakaService.GetByIdAsync(id);
            if (alpaka == null)
            {
                return NoContent();
            }
    
            return NotFound(); // Return NotFound if the ID is still found after deletion
        }



    }
}
