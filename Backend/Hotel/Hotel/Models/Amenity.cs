using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Amenity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        List<ApartmentToAmenity> ApartmentToAmenities { get; set; }


    }
}
