using System;

namespace HealthInsurance.Core.Entities
{
    public enum ExperienceType
    {
        HighSchool = 0,
        College = 1,
        BachelorDegree = 2,
        MasterDegree = 3,
        Job = 4
    }
    public class Experience : BaseIdentity
	{
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string University { get; set; }
        public string Faculty { get; set; }
        public string School { get; set; } 

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
