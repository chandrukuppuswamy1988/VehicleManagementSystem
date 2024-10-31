using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Vehicle.API.Entities;
using Vehicle.API.Helpers;
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
        /// <summary>
        /// Creates the Bus
        /// </summary>
        /// <param name="busDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> AddBus(BusDto busDto)
        {
            var busEntity = await _busesRepository.AddBus(_mapper.Map<Bus>(busDto));

            var location = Url.Action(nameof(AddBus), new { id = busEntity.Id }) ?? $"/{busEntity.Id}";
            return Results.Created(location, busEntity);
          
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<BusDto>> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var busEntity = await _busesRepository.GetBus(id);

            if (busEntity == null)
            {
                return NotFound();
            }

            var bus = _mapper.Map<BusDto>(busEntity);

            return Ok(bus);
        }

        /// <summary>
        /// Get all Buses for UI
        /// </summary>
        /// <param name="busesRP">gets search result from Query</param>
        /// <returns></returns>
        [HttpGet("GetBuses")] // Required to avoid swagger error
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] BusesRP busesRP)
        {
            var busesFromRepo = await _busesRepository.GetBuses(busesRP);

            var paginationMetadata = new
            {
                totalCount = busesFromRepo.TotalCount,
                pageSize = busesFromRepo.PageSize,
                currentPage = busesFromRepo.CurrentPage,
                totalPages = busesFromRepo.TotalPages
            };

            Response.Headers.Add("X-Pagination",
                   JsonSerializer.Serialize(paginationMetadata));

            var busDtos = _mapper.Map<IEnumerable<BusDto>>(busesFromRepo)
                               .ShapeData(busesRP.Fields);


            return Ok(busDtos);
        }
    }
}
