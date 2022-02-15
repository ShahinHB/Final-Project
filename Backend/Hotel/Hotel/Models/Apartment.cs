using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Apartment
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public double Price { get; set; }

        public string Info { get; set; }

        public List<ApartmentToAmenity> ApartmentToAmenities { get; set; }

        public List<ApartmentImage> ApartmentImages { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
