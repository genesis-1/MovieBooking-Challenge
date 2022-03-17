namespace Skillsbox.Challenge.MovieBooking.API.Model.Movie
{
    public class RunningTimeDto
    {
        public int Id { get; set; }
        public ICollection<RunningDayDto> RunningDays { get; set; }
    }
}