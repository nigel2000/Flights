using Flights.ReadModels;
using Microsoft.AspNetCore.Mvc;

namespace Flights.Controllers
{
    [ApiController]
    [Route("[controller]")]
   

    public class FlightController : ControllerBase
    {
        private readonly ILogger<FlightController> _logger;

        static Random random = new Random();

        static private FlightRm[] flights = new FlightRm[] 

            {
                new (Guid.NewGuid(),
                    "American Airlines",
                    random.Next(90,5000).ToString(),
                    new TimePlaceRm("Los Angeles", DateTime.Now.AddHours(random.Next(1,3))),
                    new TimePlaceRm("Istanbul", DateTime.Now.AddHours(random.Next(4,10))),
                    random.Next(1,853)),

                new (Guid.NewGuid(),
                    "Deutsche BA",
                    random.Next(90,5000).ToString(),
                    new TimePlaceRm("Munchen", DateTime.Now.AddHours(random.Next(1,10))),
                    new TimePlaceRm("Schipphol", DateTime.Now.AddHours(random.Next(4,15))),
                    random.Next(1,853)),

                 new (Guid.NewGuid(),
                    "British Airways",
                    random.Next(90,5000).ToString(),
                    new TimePlaceRm("London", DateTime.Now.AddHours(random.Next(1,15))),
                    new TimePlaceRm("Vizzola-Ticino", DateTime.Now.AddHours(random.Next(4,18))),
                    random.Next(1,853)),

                 new (Guid.NewGuid(),
                    "Basiq Air",
                    random.Next(90,5000).ToString(),
                    new TimePlaceRm("Amsterdam", DateTime.Now.AddHours(random.Next(1,15))),
                    new TimePlaceRm("Glasgow", DateTime.Now.AddHours(random.Next(4,18))),
                    random.Next(1,853)),

                 new (Guid.NewGuid(),
                    "Adria Aiways",
                    random.Next(90,5000).ToString(),
                    new TimePlaceRm("Ljubljana", DateTime.Now.AddHours(random.Next(1,15))),
                    new TimePlaceRm("Warsaw", DateTime.Now.AddHours(random.Next(4,18))),
                    random.Next(1,853)),

                 new (Guid.NewGuid(),
                    "ABA Air",
                    random.Next(90,5000).ToString(),
                    new TimePlaceRm("Praha Ruzyne", DateTime.Now.AddHours(random.Next(1,15))),
                    new TimePlaceRm("Paris", DateTime.Now.AddHours(random.Next(4,18))),
                    random.Next(1,853))
    };

        public FlightController(ILogger<FlightController> logger)
        {
            _logger = logger;
        }

    [HttpGet]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [ProducesResponseType(typeof(IEnumerable<FlightRm>), 200)]

    public IEnumerable<FlightRm> Search()
    => flights;

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [ProducesResponseType(typeof(FlightRm),200)]

    [HttpGet("{id}")]
    public ActionResult<FlightRm> Find(Guid id)
        {
            var flight = flights.SingleOrDefault(f => f.Id == id);

            if(flight == null)
                return NotFound();

            return Ok(flight);
        }
        
          
    }
}