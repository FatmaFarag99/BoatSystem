namespace BoatSystem.Application.City.Commands.Update
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

    public class UpdateCityCommand : ICommand<CityViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UpdateCityCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }


    public class UpdateCityHandler : ICommandHandler<UpdateCityCommand, CityViewModel>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public UpdateCityHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<CityViewModel> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetByIdAsync(request.Id);
            if(city != null)
            {
                city.Name = request.Name;
                await _cityRepository.UpdateAsync(city.Id, city);
                return _mapper.Map<CityViewModel>(city);
            }
            throw new KeyNotFoundException("City not found");
        }
    }
}
