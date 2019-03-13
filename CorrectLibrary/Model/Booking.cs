using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectLibrary
{
    public class Booking
    {
        public int BookingId { get; set; }
        public Room Room { get; set; }
        public Guest Guest { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public Booking()
        {

        }
    }
}
