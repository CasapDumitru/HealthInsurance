namespace HealthInsurance.Core.Entities
{
    public class DoctorDepartment
	{
        public User Doctor { get; set; }
        public int DoctorId { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
