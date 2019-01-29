using HealthInsurance.Core.Models;
using HealthInsurance.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthInsurance.Core.Interfaces.Services
{
    public interface IOfficeService
    {
		Task<OfficeDto> GetById(int id);
		Task<OfficeDto> GetFullById(int id);
		Task<IReadOnlyList<OfficeDto>> GetAll();
		Task<IReadOnlyList<OfficeDto>> SearchByName(string name);
		Task<OfficeDto> Add(OfficeForCreationDto office);
		Task<OfficeDto> Update(OfficeForUpdateDto office);
		Task<OfficeDto> Delete(int id);
	}
}
