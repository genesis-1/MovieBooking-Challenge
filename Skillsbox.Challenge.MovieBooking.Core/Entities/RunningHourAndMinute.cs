using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillsbox.Challenge.MovieBooking.Core.Entities
{
   public class RunningHourAndMinute
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int? RunningDayId { get; set; }
    }
}
