using Microsoft.EntityFrameworkCore;
using Vehicle.API.Entities;

namespace Vehicle.API.Repository
{
    public class VehicleDBContext : DbContext
    {

        public VehicleDBContext(DbContextOptions<VehicleDBContext> options)   : base(options)
        {
        }

        public DbSet<Bus> Buses { get; set; }

    }
}
