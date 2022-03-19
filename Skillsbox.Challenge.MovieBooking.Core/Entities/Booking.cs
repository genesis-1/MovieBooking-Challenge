using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillsbox.Challenge.MovieBooking.Core.Entities
{
    public  class Booking
    {
        public int Id { get; set; }
        public string MovieBookedBy { get; set; }
        public DateTime MovieBookedon { get; set; }

        public string BookedTime { get; set; }

        public string BookingOwnerEmail { get; set; }

        public Decimal TotalBookingPrice { get; set; }

        public int TotalBookedSeats { get; set; }

        public ICollection<Seat> BookedSeats { get; set; }
        public ICollection<Ticket> Tickets { get; set; }



    }
}
