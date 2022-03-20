namespace Skillsbox.Challenge.MovieBooking.Core.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public string Section { get; set; }
        public string ColumnNumber { get; set; }
        public string RowAlphabet { get; set; }
        public int? BookingId { get; set; }
    }
}