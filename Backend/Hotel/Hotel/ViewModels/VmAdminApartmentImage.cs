using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class VmAdminApartmentImage
    {
        public List<ApartmentImage> ApartmentImages { get; set; }
        public ApartmentImage ApartmentImage { get; set; }
        public Apartment Apartment { get; set; }
    }
}
