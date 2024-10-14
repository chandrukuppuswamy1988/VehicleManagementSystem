using System.ComponentModel.DataAnnotations;

namespace Vehicle.API.Models
{
    public class BusDto
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManufacturerName { get; set; }
        public DateTime OwnedOn { get; set; }
        public string RegstNumber { get; set; }
    }
}
