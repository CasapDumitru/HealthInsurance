using System.Collections.Generic;

namespace HealthInsurance.Core.Entities
{
    public class MedicineSpeciality : BaseIdentity
	{
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
