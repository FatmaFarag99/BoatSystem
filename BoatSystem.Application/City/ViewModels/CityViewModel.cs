namespace BoatSystem.Application.City.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AddCityViewModel
    {
        public string Name { get; set; }
    }
}
