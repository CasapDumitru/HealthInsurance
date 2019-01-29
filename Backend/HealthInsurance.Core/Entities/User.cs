using System;
using System.Collections.Generic;

namespace HealthInsurance.Core.Entities
{
    public enum  UserType
    {
        None = 0,
        Admin = 1,
        Doctor = 2
    }

    public class User : BaseIdentity
    {
        public User()
        {
            Experiences = new List<Experience>();
            CreatedOfficeReviews = new List<OfficeReview>();
            CreatedUserReviews = new List<UserReview>();           
            Offices = new List<Office>();          
            RecievedReviews = new List<UserReview>();
        }

        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public UserType UserType { get; set; }

        public Address Address { get; set; }
        public int? AddressId { get; set; }

        public IList<Office> Offices { get; set; }
        public IList<Experience> Experiences { get; set; }
        public IList<UserReview> CreatedUserReviews { get; set; }
        public IList<OfficeReview> CreatedOfficeReviews { get; set; }
        public IList<UserReview> RecievedReviews { get; set; }
        public IList<DoctorDepartment> DoctorDepartments { get; set; }
    }
}
