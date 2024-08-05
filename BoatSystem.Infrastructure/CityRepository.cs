namespace BoatRentalSystem.Infrastructure
{
    using BoatRentalSystem.Core.Entities;
    using BoatRentalSystem.Core.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CityRepository : BaseRepository<City>, ICityRepository
    {

        public CityRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        //    public async Task AddCity(City city)
        //    {
        //        await _dbContext.Cities.AddAsync(city);
        //        await _dbContext.SaveChangesAsync();
        //    }

        //    public async Task DeleteCity(int id)
        //    {
        //        var city = await _dbContext.Cities.FindAsync(id);
        //        if (city != null)
        //        {
        //            _dbContext.Cities.Remove(city);
        //            await _dbContext.SaveChangesAsync();
        //        }

        //    }

        //    public async Task<IEnumerable<City>> GetAllCities()
        //    {
        //        return await _dbContext.Cities.ToListAsync();
        //    }


        //    public async Task<City> GetCityById(int id)
        //    {
        //        var city = await _dbContext.Cities.FindAsync(id);
        //        if(city == null)
        //        {
        //            throw new KeyNotFoundException("Not found");
        //        }
        //        return city;

        //    }

        //    public async Task UpdateCity(City city)
        //    {
        //        var existingCity = await _dbContext.Cities.FindAsync(city.Id);
        //        if (existingCity != null)
        //        {
        //            existingCity.Name = city.Name;
        //            _dbContext.Cities.Update(existingCity);
        //            await _dbContext.SaveChangesAsync();
        //        }
        //    }
        //}
    }
}
