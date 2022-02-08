using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class ApartmentToAmenity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }


        [ForeignKey("Amenity")]
        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; }

    }
}
