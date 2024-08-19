namespace BoatRentalSystem.API.Controllers
{
    using AutoMapper;
    using BoatRentalSystem.Application;
    using BoatRentalSystem.Core.Entities;
    using BoatSystem.Core.Models;
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

        public CityController(CityService cityService, IMapper mapper, ILogger<CityController> logger)
        {
            _cityService = cityService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityViewModel>>> Get()
        {
            var city = await _cityService.GetAllCities();
            var cityViewModel = _mapper.Map<IEnumerable<CityViewModel>>(city);
            return Ok(cityViewModel);
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
        public async Task<ActionResult> Post([FromBody] AddCityViewModel addCityViewModel)
        {
            var city = _mapper.Map<City>(addCityViewModel);
            await _cityService.AddCity(city);
            return CreatedAtAction(nameof(Get), new {id = city.Id} , addCityViewModel);
        }

        [HttpPut]
        public async Task<ActionResult> Put(CityViewModel cityViewModel)
        {
            var existingCity = await _cityService.GetCityById(cityViewModel.Id);
            if (existingCity == null)
            {
                return NotFound();
            }
            var city = _mapper.Map<City>(cityViewModel);
            await _cityService.UpdateCity(city);
            return Ok(city);

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
