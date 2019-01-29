using AutoMapper;
using HealthInsurance.Core.Entities;

namespace HealthInsurance.Core.Models
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			// address
			CreateMap<Address, AddressDto>();
			CreateMap<AddressForCreationDto, Address>();
			CreateMap<AddressForUpdateDto, Address>();

			// department
			CreateMap<Department, DepartmentDto>();
			CreateMap<DepartmentForCreationDto, Department>();
			CreateMap<DepartmentForUpdateDto, Department>();

			// office
			CreateMap<Office, OfficeDto>();
			CreateMap<OfficeForCreationDto, Office>();
			CreateMap<OfficeForUpdateDto, Office>();

			// user
			CreateMap<User, UserDto>();
			CreateMap<UserForCreationDto, User>();
			CreateMap<OfficeForUpdateDto, User>();
		}
	}
}
