using HealthInsurance.Api.ActionFilters;
using HealthInsurance.Core.Interfaces.Services;
using HealthInsurance.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HealthInsurance.Api.Controllers
{
    /// <summary>
    /// Offices Controller
    /// </summary>
    [Route("api/offices")]
    public class OfficesController : Controller
    {
        private readonly ILogger<OfficesController> _logger;
        private readonly IOfficeService _officeService;

        public OfficesController(ILogger<OfficesController> logger, IOfficeService officeService)
        {
            _logger = logger;
            _officeService = officeService;
        }

        /// <summary>
		/// Get Office By Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
        [HttpGet("{id}", Name = "GetOffice")]
        public async Task<IActionResult> GetById(int id)
        {
            var office = await _officeService.GetFullById(id);
            return Ok(office);
        }

        /// <summary>
        /// Get all Offices
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var offices = await _officeService.GetAll();
            return Ok(offices);
        }

        /// <summary>
        /// Search Offices by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var offices = await _officeService.SearchByName(name);

            return Ok(offices);
        }

		/// <summary>
		/// Add an Office
		/// </summary>
		/// <param name="office"></param>
		/// <returns></returns>
		[HttpPost()]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
		public async Task<IActionResult> Add([FromBody] OfficeForCreationDto office)
		{
			var addedOffice = await _officeService.Add(office);
			return CreatedAtRoute("GetOffice", new { id = addedOffice.Id }, addedOffice);
		}

        /// <summary>
        /// Update an Office
        /// </summary>
        /// <param name="office"></param>
        /// <returns></returns>
        [HttpPut()]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update([FromBody] OfficeForUpdateDto office)
        {
            await _officeService.Update(office);
            return NoContent();
        }

        /// <summary>
        /// Delete Office
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var office = await _officeService.Delete(id);
            return Ok(office);
        }
	}
}
