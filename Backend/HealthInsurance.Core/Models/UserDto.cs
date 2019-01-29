using HealthInsurance.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace HealthInsurance.Core.Models
{
    // DTO Model for GET
    public class UserDto
	{
		public int Id { get; set; }
		public DateTime BirthDate { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string UserName { get; set; }
		public UserType UserType { get; set; }
	}

    // Abstract DTO Model for Create and Update
    public abstract class UserForManipulationDto
    {
        [Required(ErrorMessage = "You should fill out the usertype")]
        public UserType UserType { get; set; }

        [Required(ErrorMessage = "You should fill out a Firstname")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The FirstName length must be greater that 3 and smaller that 50")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You should fill out a Lastname")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The LastName length must be greater that 3 and smaller that 50")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You should fill out the BirthDate")]
        [Is16YearsOld(ErrorMessage = "It is necessary to be at least 16 years old")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "You should fill out a PhoneNumber")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "The Phone Number length must be greater that 5 and smaller that 20")]
        [Phone(ErrorMessage = "The Phone Number is invalid")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "You should fill out an Email")]
        [EmailAddress(ErrorMessage = "The Email address is invalid")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The Email length must be greater that 5 and smaller that 100")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You should fill out an UserName")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The UserName length must be greater that 8 and smaller that 30")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You should fill out a Password")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The Password length must be greater that 8 and smaller that 30")]
        public string Password { get; set; }
          
        [Required(ErrorMessage = "You should fill out an Address")]
        public AddressForCreationDto Address { get; set; }
    }

    // DTO Model for CREATE
    public class UserForCreationDto : UserForManipulationDto
    {
    }

    // DTO Model for UPDATE
    public class UserForUpdateDto : UserForManipulationDto
    {
        [Required(ErrorMessage = "You should specify the Id of User to update")]
        public int Id { get; set; }
    }
}
