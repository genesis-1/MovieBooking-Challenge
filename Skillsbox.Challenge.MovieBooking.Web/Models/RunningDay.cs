namespace Skillsbox.Challenge.MovieBooking.Web.Models
{
    public class RunningDay
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? RunningTimeId { get; set; }
        public ICollection<RunningHourAndMinute> RunningHourAndMinutes { get; set; } = new List<RunningHourAndMinute>();
    }
}