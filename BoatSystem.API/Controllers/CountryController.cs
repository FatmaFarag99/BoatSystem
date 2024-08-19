namespace BoatRentalSystem.API.Controllers
{
    using AutoMapper;
    using BoatRentalSystem.Application;
    using BoatRentalSystem.Core.Entities;
    using BoatSystem.Core.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = SwaggerDocsConstant.Admin)]

    public class CountryController : ControllerBase
    {
        private readonly CountryService _CountryService;
        private readonly IMapper _mapper;

        public CountryController(CountryService CountryService, IMapper mapper)
        {
            _CountryService = CountryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryViewModel>>> Get()
        {
            var Country = await _CountryService.GetAllCountries();
            var CountryViewModel = _mapper.Map<IEnumerable<CountryViewModel>>(Country);
            return Ok(CountryViewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryViewModel>> Get(int id)
        {
            var Country = await _CountryService.GetCountryById(id);
            if (Country == null)
            {
                return NotFound();
            }
            var CountryViewModel = _mapper.Map<CountryViewModel>(Country);
            return Ok(CountryViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddCountryViewModel addCountryViewModel)
        {
            var Country = _mapper.Map<Country>(addCountryViewModel);
            await _CountryService.AddCountry(Country);
            return CreatedAtAction(nameof(Get), new { id = Country.Id }, addCountryViewModel);
        }

        [HttpPut]
        public async Task<ActionResult> Put(CountryViewModel CountryViewModel)
        {
            var existingCountry = await _CountryService.GetCountryById(CountryViewModel.Id);
            if (existingCountry == null)
            {
                return NotFound();
            }
            var Country = _mapper.Map<Country>(CountryViewModel);
            await _CountryService.UpdateCountry(Country);
            return Ok(Country);

        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var existingCountry = await _CountryService.GetCountryById(id);
            if (existingCountry == null)
            {
                return NotFound();
            }
            await _CountryService.DeleteCountry(id);
            return NoContent();
        }
    }

}
