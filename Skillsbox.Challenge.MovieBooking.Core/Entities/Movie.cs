using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillsbox.Challenge.MovieBooking.Core.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Genre { get; set; }
        public string Notes { get; set; }

        public string ImageUrl { get; set; }

        public decimal Duration { get; set; }
        
        public int? RunningTimeId { get; set; }
        public RunningTime RunningTime { get; set; }
    }
}
