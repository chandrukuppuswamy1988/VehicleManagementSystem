using Microsoft.EntityFrameworkCore;
using Vehicle.API.Entities;
using Vehicle.API.Helpers;
using Vehicle.API.Models;

namespace Vehicle.API.Repository
{
    public class BusesRepository : IBusesRepository
    {

        private readonly VehicleDBContext _context;
        public BusesRepository(VehicleDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IList<Bus>> GetBuses()
        {
            return await _context.Buses.ToListAsync<Bus>();
        }

        public async Task<PagedList<Bus>> GetBuses(BusesRP busesRP)
        {

            var collection = _context.Buses as IQueryable<Bus>;
            return await PagedList<Bus>.CreateAsync(collection, busesRP.PageNumber, busesRP.PageSize);

        }
        public async Task<Bus> GetBus(int id)
        {
            return await _context.Buses.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Bus> AddBus(Bus bus)
        {
            await _context.Buses.AddAsync(bus);
            _context.SaveChanges();

            return bus;
        }

    }
}
