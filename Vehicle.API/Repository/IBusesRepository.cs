using Vehicle.API.Entities;
using Vehicle.API.Helpers;
using Vehicle.API.Models;

namespace Vehicle.API.Repository
{
    public interface IBusesRepository
    {
        Task<Bus> AddBus(Bus bus);
        Task<Bus> GetBus(int id);
        Task<IList<Bus>> GetBuses();
        Task<PagedList<Bus>> GetBuses(BusesRP busesRP);
    }
}