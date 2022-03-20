namespace Skillsbox.Challenge.MovieBooking.API.Model.Movie
{
    public class MovieListDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string ImageUrl { get; set; }
        public decimal Duration { get; set; }

        public ICollection<RunningHourAndMinuteDto> RunningHours { get; set; }

    }
}
