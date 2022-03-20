namespace Skillsbox.Challenge.MovieBooking.Web.Models
{
    public class RunningTime
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public ICollection<RunningDay> RunningDays { get; set; } = new List<RunningDay>();
    }
}