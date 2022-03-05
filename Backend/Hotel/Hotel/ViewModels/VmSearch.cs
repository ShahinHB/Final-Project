using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class VmSearch
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int adultCount { get; set; }
        public int kidCount { get; set; }
    }
}
