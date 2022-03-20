namespace Skillsbox.Challenge.MovieBooking.API.Model.Movie
{
    public class RunningDayDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? RunningTimeId { get; set; }
        public ICollection<RunningHourAndMinuteDto> RunningHourAndMinutes { get; set; }
    }
}