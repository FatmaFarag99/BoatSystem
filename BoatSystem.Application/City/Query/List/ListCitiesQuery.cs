namespace BoatSystem.Application.City.Query.List
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

    public class ListCitiesQuery : ICommand<IEnumerable<CityViewModel>>
    {
    }

    public class ListCitiesHandler : IQueryHandler<ListCitiesQuery, IEnumerable<CityViewModel>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public ListCitiesHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CityViewModel>> Handle(ListCitiesQuery request, CancellationToken cancellationToken)
        {
            var cities = await _cityRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CityViewModel>>(cities);
        }
    }
}
