using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.Models
{
    public class Social
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }
    }
}
