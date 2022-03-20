namespace Skillsbox.Challenge.MovieBooking.API.Model.Movie
{

    public class MovieArray
    {
        public string? Title { get; set; }
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Cast { get; set; }
        public string? Genre { get; set; }
        public string? Notes { get; set; }
        public int Id { get; set; }
        public RunningtimesList? RunningTimes { get; set; }

        public class RunningtimesList
        {
            public string[]? Mon { get; set; }
            public string[]? Tue { get; set; }
            public string[]? Wed { get; set; }
            public string[]? Thu { get; set; }
            public string[]? Fri { get; set; }
            public string[]? Sat { get; set; }
            public string[]? Sun { get; set; }
        }
    }
}
