using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillsbox.Challenge.MovieBooking.Core.Entities
{
    public class RunningTime
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public ICollection<RunningDay> RunningDays { get; set; }

    }
}
