using Vehicle.API.Entities;

namespace Vehicle.API.Repository
{
    public interface IBusesRepository
    {
        Task<IList<Bus>> GetBuses();
    }
}