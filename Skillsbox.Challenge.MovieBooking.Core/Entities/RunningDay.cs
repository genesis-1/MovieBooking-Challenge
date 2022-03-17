using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillsbox.Challenge.MovieBooking.Core.Entities
{
    public class RunningDay
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? RunningTimeId { get; set; }
        public ICollection<RunningHourAndMinute> RunningHourAndMinutes { get; set; }
    }
}
