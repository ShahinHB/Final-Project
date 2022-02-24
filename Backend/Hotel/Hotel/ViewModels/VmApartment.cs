using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class VmApartment : VmLayout
    {
        public List<Apartment> Apartments { get; set; }
        public List<Amenity> Amenities { get; set; }
        public List<ApartmentImage> ApartmentImages { get; set; }
    }
}
