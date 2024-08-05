namespace BoatRentalSystem.API.Controllers
{
    using AutoMapper;
    using BoatRentalSystem.Core.Entities;

    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AddCityViewModel
    {
        public string Name { get; set; }
    }


    public class CountryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AddCountryViewModel
    {
        public string Name { get; set; }
    }


    public class  MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityViewModel>().ReverseMap();
            CreateMap<City, AddCityViewModel>().ReverseMap();

            CreateMap<Country, CountryViewModel>().ReverseMap();
            CreateMap<Country, AddCountryViewModel>().ReverseMap();
        }
    }
}
