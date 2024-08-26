namespace BoatRentalSystem.API.Controllers
{
    using AutoMapper;
    using BoatRentalSystem.Application;
    using BoatRentalSystem.Core.Entities;
    using BoatSystem.Application.City.Commands.Add;
    using BoatSystem.Application.City.Commands.Update;
    using BoatSystem.Application.City.Query.List;
    using BoatSystem.Application.City.ViewModels;
    using BoatSystem.Core.Models;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = SwaggerDocsConstant.User)]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;
        private readonly IMapper _mapper;
        private readonly ILogger<CityController> _logger;
        private readonly IMediator _mediator;

        public CityController(CityService cityService, IMapper mapper, ILogger<CityController> logger, IMediator mediator)
        {
            _cityService = cityService;
            _mapper = mapper;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var city = new ListCitiesQuery();
            var cities = await _mediator.Send(city);
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityViewModel>> Get(int id)
        {
            var city = await _cityService.GetCityById(id);
            _logger.LogInformation($"Get City By id = {id}");
            if (city == null)
            {
                _logger.LogError($"City with id : {id} not found");
                return NotFound();
            }
            var cityViewModel = _mapper.Map<CityViewModel>(city);
            return Ok(cityViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCityCommand command)
        {
            if (command == null)
            {
                return BadRequest("City data is required");
            }
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCityCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return BadRequest("error in update city");
            }
            return Ok(result);

        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var existingCity = await _cityService.GetCityById(id);
            if (existingCity == null)
            {
                return NotFound();
            }
            await _cityService.DeleteCity(id);
            return NoContent();
        }
    }

}
