using System.Collections.Generic;

namespace HealthInsurance.Core.Entities
{
    public class Office : BaseIdentity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public User Owner { get; set; }
        public int? OwnerId { get; set; }
        public Address Address { get; set; }
        public int? AddressId { get; set; }

        public ICollection<Department> Departments { get; set; }
        public ICollection<OfficeReview> RecievedReviews { get; set; }
    }
}
