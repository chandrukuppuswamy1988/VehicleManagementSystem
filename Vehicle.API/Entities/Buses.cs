using System.ComponentModel.DataAnnotations;

namespace Vehicle.API.Entities
{
    public class Bus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManufacturerName { get; set; }
        public DateTime OwnedOn { get; set; }
        public string RegstNumber { get; set; }
    }
}
