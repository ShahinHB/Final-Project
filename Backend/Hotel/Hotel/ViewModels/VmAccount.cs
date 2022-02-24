using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class VmAccount
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public AdminPanelUser User { get; set; }
    }
}
