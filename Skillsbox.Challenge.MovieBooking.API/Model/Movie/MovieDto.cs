namespace Skillsbox.Challenge.MovieBooking.API.Model.Movie
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Genre { get; set; }
        public string Notes { get; set; }
        public int? RunningTimeId { get; set; }

        public RunningTimeDto RunningTime { get; set; }
    }
}