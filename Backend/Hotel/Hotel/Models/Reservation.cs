using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        //Reservation Details
        public int AdultsCount { get; set; }
        public int KidsCount { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Customer Details
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; } = false;

        public string SpecialRequest { get; set; }
        public DateTime CreatedDate { get; set; }
        public double Amount { get; set; }

        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

        
    }
}
