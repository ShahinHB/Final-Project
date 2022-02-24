using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class VmHome : VmLayout
    {
        public AboutApartment AboutApartment { get; set; }
        public Location Location { get; set; }
        public Feedback Feedback { get; set; }

    }
}
