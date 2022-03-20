namespace Skillsbox.Challenge.MovieBooking.Web.Models
{
    public class RunningHourAndMinute
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int? RunningDayId { get; set; }
    }
}