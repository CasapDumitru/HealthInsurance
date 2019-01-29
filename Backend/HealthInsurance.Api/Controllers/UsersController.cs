using HealthInsurance.Core.Interfaces.Services;
using HealthInsurance.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthInsurance.Api.Controllers
{
	[Route("api/users")]
	public class UsersController : Controller
	{
		private IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet()]
		public async Task<IActionResult> GetUsers()
		{
			var users = await _userService.GetAll();
			return Ok(users);
		}

		[HttpGet("{id}", Name = "GetUser")]
		public async Task<IActionResult> GetUser(int id)
		{
			var user = await _userService.GetById(id);
			return Ok(user);
		}

		[HttpPost()]
		public async Task<IActionResult> AddUser([FromBody] UserForCreationDto user)
		{
			if (user == null)
			{
				return BadRequest();
			}

			var addedUser = await _userService.Add(user);

			return CreatedAtRoute("GetUser",
				new { id = addedUser.Id },
				addedUser);
		}

        [HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			var user = await _userService.Delete(id);

			return Ok(user);
		}
	}
}
