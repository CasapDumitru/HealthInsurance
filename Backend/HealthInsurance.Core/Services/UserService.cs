using AutoMapper;
using HealthInsurance.Core.Entities;
using HealthInsurance.Core.Exceptions;
using HealthInsurance.Core.Interfaces.Services;
using HealthInsurance.Core.Interfaces.Specifications;
using HealthInsurance.Core.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthInsurance.Core.Services
{
    public class UserService : IUserService
	{
        private ILogger _logger;
		private IMapper _mapper;
		private IUnitOfWork _unitOfWork;
		private IRepository _repository;

		public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger)
		{   
			_unitOfWork = unitOfWork;
			_repository = unitOfWork.Repository;
            _mapper = mapper;
            _logger = logger;
        }

		public async Task<UserDto> GetById(int id)
		{
			var user = await _repository.GetById<User>(id);

            if(user == null)
            {
                throw new NotFoundException($"User with Id = {id} is not found");
            }

			return Mapper.Map<UserDto>(user);
		}

		public async Task<IReadOnlyList<UserDto>> GetAll()
		{
			var users = await _repository.GetAll<User>();

			return Mapper.Map<IReadOnlyList<UserDto>>(users);
		}

		public async Task<UserDto> Add(UserForCreationDto user)
		{
			var userEntity = _mapper.Map<User>(user);

			await _repository.Add(userEntity);
			await _unitOfWork.SaveChanges();

			return _mapper.Map<UserDto>(userEntity);
		}

		public async Task<UserDto> Update(UserForUpdateDto user)
		{
			var userEntity = _mapper.Map<User>(user);

			_repository.Update(userEntity);
			await _unitOfWork.SaveChanges();

			return _mapper.Map<UserDto>(userEntity);
		}

		public async Task<UserDto> Delete(int id)
		{
			var user = await _repository.GetById<User>(id);

            if (user == null)
            {
                throw new NotFoundException($"User with Id = {id} is not found");
            }

            _repository.Delete(user);

			return _mapper.Map<UserDto>(user);
		}
	}
}
