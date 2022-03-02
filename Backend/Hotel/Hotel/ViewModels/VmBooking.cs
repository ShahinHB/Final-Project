using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class VmBooking : VmLayout
    {
        public Reservation Reservation { get; set; }

    }
}
