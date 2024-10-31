using Microsoft.EntityFrameworkCore;
using Vehicle.API.Entities;
using Vehicle.API.Helpers;
using Vehicle.API.Models;

namespace Vehicle.API.Repository
{
    public class BusesRepository : IBusesRepository
    {

        private readonly VehicleDBContext _context;
        private readonly ILogger<BusesRepository> _logger;
        public BusesRepository(VehicleDBContext context, ILogger<BusesRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            this._logger = logger ?? throw new ArgumentNullException(nameof(ILogger<BusesRepository>));
        }

        public async Task<IList<Bus>> GetBuses()
        {
            try
            {
                return await _context.Buses.ToListAsync<Bus>();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
            }
            return null;
        }

        public async Task<PagedList<Bus>> GetBuses(BusesRP busesRP)
        {

            try
            {
                var collection = _context.Buses as IQueryable<Bus>;
                return await PagedList<Bus>.CreateAsync(collection, busesRP.PageNumber, busesRP.PageSize);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
            }
            return null;
        }
        public async Task<Bus> GetBus(int id)
        {
            try
            {
                return await _context.Buses.Where(p => p.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
            }
            return null;

        }
        public async Task<Bus> AddBus(Bus bus)
        {
            try
            {

                await _context.Buses.AddAsync(bus);
                _context.SaveChanges();

                return bus;

            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
            }

            return null;
        }

    }
}
