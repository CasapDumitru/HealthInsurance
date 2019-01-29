using HealthInsurance.Api.ActionFilters;
using HealthInsurance.Core.Interfaces.Services;
using HealthInsurance.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
		/// GET All Offices
		/// </summary>
		/// <returns></returns>
		[HttpGet()]
        public async Task<IActionResult> Get()
        {
            throw new Exception("SOmething bad");
            var offices = await _officeService.SearchByName("Maria");
            _logger.LogWarning("You did a big mistake!");
            return Ok(offices);
        }

		/// <summary>
		/// GET Office By Id
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
		/// ADD an Office
		/// </summary>
		/// <param name="office"></param>
		/// <returns></returns>
		[HttpPost()]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
		public async Task<IActionResult> AddOffice([FromBody] OfficeForCreationDto office)
		{
			var addedOffice = await _officeService.Add(office);

			return CreatedAtRoute("GetOffice", new { id = addedOffice.Id }, addedOffice);
		}
	}
}
