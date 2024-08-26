namespace BoatSystem.Application.City.Commands.Add
{
    using AutoMapper;
    using BoatRentalSystem.Core.Interfaces;
    using BoatSystem.Application.City.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using BoatRentalSystem.Core.Entities;
    public class AddCityCommand : ICommand<CityViewModel>
    {
        public string Name { get; set; }
        public AddCityCommand(string name)
        {
            Name = name;
        }
    }


    public class AddCityHandler : ICommandHandler<AddCityCommand, CityViewModel>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public AddCityHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<CityViewModel> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
            var city = new City {  Name = request.Name };
            await _cityRepository.AddAsync(city);
            return _mapper.Map<CityViewModel>(city);
        }
    }
}
