using System.ComponentModel.DataAnnotations;

namespace HealthInsurance.Core.Models
{
    // DTO Model for GET
	public class AddressDto
	{
		public int Id { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public string PostalCode { get; set; }
	}

    // Abstract DTO Model for Create and Update
    public abstract class AddressForManipulationDto
    {
        [Required(ErrorMessage = "You should fill out a Country")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The Country name length must be greater that 3 and smaller that 30")]
        public string Country { get; set; }

        [[Required(ErrorMessage = "You should fill out a City")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The City name length must be greater that 3 and smaller that 30")]
        public string City { get; set; }

        [Required(ErrorMessage = "You should fill out a Street")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "The Street name length must be greater that 3 and smaller that 70")]
        public string Street { get; set; }

        [Required(ErrorMessage = "You should fill out a Street Number")]
        [MaxLength(10, ErrorMessage = "The Street Number length must be smaller that 10")]
        public string StreetNumber { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "The PostalCode length must be greater that 3 and smaller that 20")]
        public string PostalCode { get; set; }
    }

    // DTO Model for CREATE
    public class AddressForCreationDto : AddressForManipulationDto
    {

    }


    // DTO Model for UPDATE
    public class AddressForUpdateDto : AddressForManipulationDto
    {
        [Required(ErrorMessage = "You should specify the Id of Address to update")]
        public int Id { get; set; }
    }
}
