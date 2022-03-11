using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;

namespace Hotel.ViewModels
{
    public class VmApartmentDetails : VmLayout
    {
        public Apartment Apartment { get; set; }
        public Reservation Reservation { get; set; }
        public List<Reservation> Reservations { get; set; }
        public int DifferDate { get; set; }

        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        //public int KidCount { get; set; }
        //public int AdultCount { get; set; }
    }
}
