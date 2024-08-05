namespace BoatRentalSystem.Application
{
    using BoatRentalSystem.Core.Entities;
    using BoatRentalSystem.Core.Interfaces;


    public class CityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public Task<IEnumerable<City>> GetAllCities()
        {
            return _cityRepository.GetAllAsync();
        }
        public Task<City> GetCityById(int id)
        {
            return _cityRepository.GetByIdAsync(id);

        }
        public Task AddCity(City city)
        {
            return _cityRepository.AddAsync(city);
        }

        public Task UpdateCity(City city)
        {
            return _cityRepository.UpdateAsync(city.Id,city);
        }

        public Task DeleteCity(int id)
        {
            return _cityRepository.DeleteAsync(id);
        }

    }
}
