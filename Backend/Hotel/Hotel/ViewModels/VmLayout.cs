using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class VmLayout
    {
        public Sub Sub { get; set; }

        public Setting Setting { get; set; }

        public List<Social> Socials { get; set; }
    }
}
