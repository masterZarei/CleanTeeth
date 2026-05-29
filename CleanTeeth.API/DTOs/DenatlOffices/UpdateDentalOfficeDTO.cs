using System.ComponentModel.DataAnnotations;

namespace CleanTeeth.API.DTOs.DenatlOffices
{
    public class UpdateDentalOfficeDTO
    {
        [Required]
        [StringLength(150)]
        public required string Name { get; set; }
    }
}
