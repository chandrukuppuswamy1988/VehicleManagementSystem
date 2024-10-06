using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Vehicle.API.Entities;
using Vehicle.API.Repository;

namespace Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        IBusesRepository _busesRepository;
        public BusesController(IBusesRepository busesRepository)
        {
            _busesRepository = busesRepository ?? throw new ArgumentException(nameof(IBusesRepository));
            
        }
        [HttpGet("GetAllBuses")]
        public async Task<ActionResult<IEnumerable<Bus>>> GetAllBuses()
        {
            var buses = await _busesRepository.GetBuses();
            return Ok(buses);
        }
    }
}
