namespace BoatRentalSystem.Application
{
    using BoatRentalSystem.Core.Entities;
    using BoatRentalSystem.Core.Interfaces;

    public class CountryService
    {
        private readonly ICountryRepository _CountryRepository;

        public CountryService(ICountryRepository CountryRepository)
        {
            _CountryRepository = CountryRepository;
        }

        public Task<IEnumerable<Country>> GetAllCountries()
        {
            return _CountryRepository.GetAllAsync();
        }
        public Task<Country> GetCountryById(int id)
        {
            return _CountryRepository.GetByIdAsync(id);

        }
        public Task AddCountry(Country Country)
        {
            return _CountryRepository.AddAsync(Country);
        }

        public Task UpdateCountry(Country Country)
        {
            return _CountryRepository.UpdateAsync(Country.Id,Country);
        }

        public Task DeleteCountry(int id)
        {
            return _CountryRepository.DeleteAsync(id);
        }

    }
}
