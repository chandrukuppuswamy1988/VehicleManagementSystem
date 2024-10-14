using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Vehicle.API.Entities;
using Vehicle.API.Models;
using Vehicle.API.Repository;

namespace Vehicle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        IBusesRepository _busesRepository;
        IMapper _mapper;
        public BusesController(IBusesRepository busesRepository, IMapper mapper)
        {
            _mapper = mapper;
            _busesRepository = busesRepository ?? throw new ArgumentException(nameof(IBusesRepository));            
        }

        /// <summary>
        /// Returns the buses arrays
        /// </summary>
        /// <returns>Buses collections</returns>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BusDto>>> GetAllBuses()
        {            

            var buses = await _busesRepository.GetBuses();
            var busDto = _mapper.Map<List<BusDto>>(buses);

            return Ok(busDto);
        }


    }
}
