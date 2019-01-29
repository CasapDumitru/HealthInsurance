using System.Collections.Generic;

namespace HealthInsurance.Core.Entities
{
    public class Department : BaseIdentity
	{
        public string Name { get; set; }
        public string Description { get; set; }
        
        public MedicineSpeciality MedicineSpeciality { get; set; }
        public int? MedicineSpecialityId { get; set; }
        public Office Office { get; set; }
        public int OfficeId { get; set; }
        
        public ICollection<DoctorDepartment> DoctorDepartments { get; set; }
    }
}
