namespace BoatRentalSystem.Core.Interfaces
{
    using BoatRentalSystem.Core.Entities;
    using BoatSystem.Core.Entities;

    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(int id,TEntity entity);
        Task DeleteAsync(int id);
    }


    public interface IOwnerRepository : IBaseRepository<Owner>
    {
        Task<Owner> GetByUserIdAsync(string userId);
    }

    public interface ICityRepository : IBaseRepository<City>
    {
        //Task<IEnumerable<City>> GetAllCities();
        //Task<City> GetCityById(int id);
        //Task AddCity(City city);
        //Task UpdateCity(City city);
        //Task DeleteCity(int id);
    }


    public interface ICountryRepository : IBaseRepository<Country>
    {
        //Task<IEnumerable<Country>> GetAllCountries();
        //Task<Country> GetCountryById(int id);
        //Task AddCountry(Country country);
        //Task UpdateCountry(Country country);
        //Task DeleteCountry(int id);
    }
}
