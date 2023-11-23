using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAlpaka.Model;
using Microsoft.Extensions.DependencyInjection;


namespace RestAlpaka.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AlpakaController : ControllerBase
    {
        private readonly AlpakaDbContext _context;

        public AlpakaController(AlpakaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Alpaka>> Get()
        {
            return _context.Alpakas.ToList();
        }

    }
}
