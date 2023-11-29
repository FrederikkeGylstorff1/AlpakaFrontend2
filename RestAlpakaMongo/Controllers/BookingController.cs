using Microsoft.AspNetCore.Mvc;
using RestAlpakaMongo.Models;
using RestAlpakaMongo.Services;

namespace RestAlpakaMongo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }


        // GET: api/Booking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAllBooking()
        {
            var Bookings = await _bookingService.GetAllAsync();
            return Ok(Bookings);
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(string id)
        {
            var bookings = await _bookingService.GetByIdAsync(id);
            if (bookings == null)
            {
                return NotFound();
            }
            return Ok(bookings);
        }

        // POST: api/Booking
        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(Booking b)
        {
            await _bookingService.CreateAsync(b);
            return CreatedAtAction("GetAlpaka", new { id = b.Id }, b);
        }

        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(string id, Booking b)
        {
            if (id != b.Id)
            {
                return BadRequest();
            }
            await _bookingService.UpdateAsync(id, b);
            return NoContent();
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBooking(string id)
        {
            var booking = await _bookingService.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            await _bookingService.DeleteAsync(id);
            return NoContent();
        }

    }
}
