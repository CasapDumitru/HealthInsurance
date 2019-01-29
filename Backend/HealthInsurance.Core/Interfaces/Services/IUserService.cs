using HealthInsurance.Core.Models;
using HealthInsurance.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthInsurance.Core.Interfaces.Services
{
	public interface IUserService
	{
		Task<UserDto> GetById(int id);
		Task<IReadOnlyList<UserDto>> GetAll();
		Task<UserDto> Add(UserForCreationDto user);
		Task<UserDto> Update(UserForUpdateDto user);
		Task<UserDto> Delete(int id);
	}
}
