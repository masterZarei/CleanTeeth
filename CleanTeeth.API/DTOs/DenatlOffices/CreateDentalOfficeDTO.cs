using System.ComponentModel.DataAnnotations;

namespace CleanTeeth.API.DTOs.DenatlOffices
{
    public class CreateDentalOfficeDTO
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
    }
}
