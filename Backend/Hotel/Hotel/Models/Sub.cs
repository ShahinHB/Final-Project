using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Sub
    {
        [Key]
        public int Id { get; set; }

        public string MailAddress { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
