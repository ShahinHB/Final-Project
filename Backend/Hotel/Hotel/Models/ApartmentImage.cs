using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Hotel.Models
{
    public class ApartmentImage
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }


        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

    }
}
