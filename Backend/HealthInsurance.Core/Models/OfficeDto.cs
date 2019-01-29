using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthInsurance.Core.Models
{
    // DTO Model for GET
    public class OfficeDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public UserDto Owner { get; set; }
		public AddressDto Address { get; set; }

		public ICollection<DepartmentDto> Departments { get; set; }
	}

    // Abstract DTO Model for Create and Update
    public abstract class OfficeForManipulationDto
    {
        [Required(ErrorMessage = "You should fill out a Name for the Office")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The Name length must be greater that 3 and smaller that 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You should fill out a Description for the Office")]
        [StringLength(1500, MinimumLength = 3, ErrorMessage = "The Name length must be greater that 20 and smaller that 1500")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You should specify the Owner ID")]
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "You should fill out the Address")]
        public AddressDto Address { get; set; }
    }

    // DTO Model for CREATE
    public class OfficeForCreationDto : OfficeForManipulationDto
    {
        public ICollection<DepartmentForCreationDto> Departments { get; set; }
            = new List<DepartmentForCreationDto>();
    }

    // DTO Model for UPDATE
    public class OfficeForUpdateDto : OfficeForManipulationDto
    {
        [Required(ErrorMessage = "You should specify the Id of Office to update")]
        public int Id { get; set; }
    }
}
