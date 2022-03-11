using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class VmApartmentReservation : VmLayout
    {
        public List<Reservation> Reservations { get; set; }
    }
}
