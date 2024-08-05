namespace BoatRentalSystem.Infrastructure
{
    using BoatRentalSystem.Core.Entities;
    using BoatRentalSystem.Core.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {


        public CountryRepository(ApplicationDbContext dbContext) : base(dbContext) { }
       
        //    public async Task AddCountry(Country Country)
        //    {
        //        await _dbContext.Countries.AddAsync(Country);
        //        await _dbContext.SaveChangesAsync();
        //    }

        //    public async Task DeleteCountry(int id)
        //    {
        //        var Country = await _dbContext.Countries.FindAsync(id);
        //        if (Country != null)
        //        {
        //            _dbContext.Countries.Remove(Country);
        //            await _dbContext.SaveChangesAsync();
        //        }

        //    }

        //    public async Task<IEnumerable<Country>> GetAllCountries()
        //    {
        //        return await _dbContext.Countries.ToListAsync();
        //    }


        //    public async Task<Country> GetCountryById(int id)
        //    {
        //        var Country = await _dbContext.Countries.FindAsync(id);
        //        if (Country == null)
        //        {
        //            throw new KeyNotFoundException("Not found");
        //        }
        //        return Country;

        //    }

        //    public async Task UpdateCountry(Country Country)
        //    {
        //        var existingCountry = await _dbContext.Countries.FindAsync(Country.Id);
        //        if (existingCountry != null)
        //        {
        //            existingCountry.Name = Country.Name;
        //            _dbContext.Countries.Update(existingCountry);
        //            await _dbContext.SaveChangesAsync();
        //        }
        //    }
        //}
    }
}