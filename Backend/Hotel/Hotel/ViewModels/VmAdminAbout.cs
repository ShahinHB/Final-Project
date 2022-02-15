using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class VmAdminAbout
    {
        public List<AboutApartment> AboutApartment { get; set; }
        public List<AboutCity> AboutCities { get; set; }
        public List<AboutGames> AboutGames { get; set; }
        public List<Location> Locations { get; set; }
        public List<Feedback> Feedbacks { get; set; }


    }
}
