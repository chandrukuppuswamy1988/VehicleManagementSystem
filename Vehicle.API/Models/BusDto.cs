using System.ComponentModel.DataAnnotations;

namespace Vehicle.API.Models
{
    public class BusDto
    {
        
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string ManufacturerName { get; set; }
        public DateTime OwnedOn { get; set; }
        public string RegstNumber { get; set; }
    }
}
