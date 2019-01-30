using HealthInsurance.Api.ActionFilters;
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

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		[HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns></returns>
		[HttpGet()]
		public async Task<IActionResult> Get()
		{
			var users = await _userService.GetAll();
			return Ok(users);
		}
   
        /// <summary>
        /// Add an User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
		[HttpPost()]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Add([FromBody] UserForCreationDto user)
		{
			var addedUser = await _userService.Add(user);
			return CreatedAtRoute("GetUser", new { id = addedUser.Id }, addedUser);
		}

        /// <summary>
        /// Update an User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut()]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update([FromBody] UserForUpdateDto user)
        {
            await _userService.Update(user);
            return NoContent();
        }

        /// <summary>
        /// Delete an User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var user = await _userService.Delete(id);
			return Ok(user);
		}
	}
}
