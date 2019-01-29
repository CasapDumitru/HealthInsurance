using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthInsurance.Core.Interfaces.Services;
using HealthInsurance.Core.Interfaces.Specifications;
using HealthInsurance.Core.Models;
using HealthInsurance.Core.Entities;
//using Microsoft.Extensions.Logging;

namespace HealthInsurance.Core.Services
{
	public class UserService : IUserService
	{
        //private ILogger _logger;
		private IMapper _mapper;
		private IUnitOfWork _unitOfWork;
		private IRepository _repository;

		public UserService(IMapper mapper, IUnitOfWork unitOfWork)
		{
            //_logger = logger;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_repository = unitOfWork.Repository;
		}

		public async Task<UserDto> GetById(int id)
		{
			var user = await _repository.GetById<User>(id);
			var userDto = Mapper.Map<UserDto>(user);
			return userDto;
		}

		public async Task<IReadOnlyList<UserDto>> GetAll()
		{
            //_logger.LogWarning("Something is not gooood :( :(!");
			var users = await _repository.GetAll<User>();
			var usersDto = Mapper.Map<IReadOnlyList<UserDto>>(users);
			return usersDto;
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
			_repository.Delete(user);

			return _mapper.Map<UserDto>(user);
		}
	}
}
