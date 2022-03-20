namespace Skillsbox.Challenge.MovieBooking.API.Model.Movie
{
    public class GetMovieDto
    {

        public string? Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Genre { get; set; }
        public string Notes { get; set; }
        public string ImageUrl { get; set; }
        public decimal Duration { get; set; }
    }
}