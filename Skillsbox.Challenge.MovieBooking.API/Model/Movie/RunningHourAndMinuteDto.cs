namespace Skillsbox.Challenge.MovieBooking.API.Model.Movie
{
    public class RunningHourAndMinuteDto
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public int? RunningDayId { get; set; }
    }
}