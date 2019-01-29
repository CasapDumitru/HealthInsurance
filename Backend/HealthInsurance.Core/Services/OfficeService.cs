using AutoMapper;
using HealthInsurance.Core.Interfaces.Services;
using HealthInsurance.Core.Interfaces.Specifications;
using HealthInsurance.Core.Models;
using HealthInsurance.Core.Entities;
using HealthInsurance.Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthInsurance.Core.Exceptions;

namespace HealthInsurance.Core.Services
{
	public class OfficeService : IOfficeService
    {
		private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
		private IRepository _repository;

        public OfficeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_mapper = mapper;
            _unitOfWork = unitOfWork;
			_repository = unitOfWork.Repository;
        }

		public async Task<IReadOnlyList<OfficeDto>> GetAll()
		{
			var offices = await _repository.GetAll<Office>();

			return _mapper.Map<IReadOnlyList<OfficeDto>>(offices);
		}

		public async Task<OfficeDto> GetById(int id)
		{
			var office = await _repository.GetById<Office>(id);

            if(office == null)
            {
                throw new NotFoundException($"Office with Id = {id} is not found");
            }

			return _mapper.Map<OfficeDto>(office);
		}

		public async Task<OfficeDto> GetFullById(int id)
		{
			var specification = new FullOfficeByIdSpecification(id);
			var office = await _repository.GetSingleBySpecification(specification);

            if (office == null)
            {
                throw new NotFoundException($"Office with Id = {id} is not found");
            }

            var officeDto = _mapper.Map<OfficeDto>(office);

			return officeDto;
		}

		public async Task<IReadOnlyList<OfficeDto>> SearchByName(string name)
		{
			var specification = new OfficeByNameSpecification(name);
			var offices = await _repository.GetBySpecification(specification);

			return _mapper.Map<IReadOnlyList<OfficeDto>>(offices);
		}

		public async Task<OfficeDto> Add(OfficeForCreationDto office)
		{
			var officeEntity = _mapper.Map<Office>(office);

			var addedOffice = await _repository.Add(officeEntity);
			await _unitOfWork.SaveChanges();

			return _mapper.Map<OfficeDto>(addedOffice);
		}

		public async Task<OfficeDto> Update(OfficeForUpdateDto office)
		{
			var officeEntity = _mapper.Map<Office>(office);

			_repository.Update(officeEntity);
			await _unitOfWork.SaveChanges();

			return _mapper.Map<OfficeDto>(officeEntity);
		}

		public async Task<OfficeDto> Delete(int id)
		{
			var office = _repository.GetById<Office>(id);

			if(office != null)
				_repository.Delete(office.Result);

			await _unitOfWork.SaveChanges();

			return _mapper.Map<OfficeDto>(office);
		}	
	}
}
