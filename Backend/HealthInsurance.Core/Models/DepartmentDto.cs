using System.ComponentModel.DataAnnotations;

namespace HealthInsurance.Core.Models
{
    // DTO Model for GET
    public class DepartmentDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}

    // Abstract DTO Model for Create and Update
    public abstract class DepartmentForManipulationDto
    {
        [Required(ErrorMessage = "You should fill out a Name for the Department")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The Name length must be greater that 3 and smaller that 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You should fill out a Description for the Department")]
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "The Name length must be greater that 20 and smaller that 1000")]
        public string Description { get; set; }
    }

    // DTO Model for CREATE
    public class DepartmentForCreationDto : DepartmentForManipulationDto
    {

    }

    // DTO Model for UPDATE
    public class DepartmentForUpdateDto : DepartmentForManipulationDto
    {
        [Required(ErrorMessage = "You should specify the Id of Department in order to update")]
        public int Id { get; set; }
    }
}
