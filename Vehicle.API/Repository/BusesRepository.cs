using Microsoft.EntityFrameworkCore;
using Vehicle.API.Entities;

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
    }
}
