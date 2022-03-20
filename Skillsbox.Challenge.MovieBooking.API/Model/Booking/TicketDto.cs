namespace Skillsbox.Challenge.MovieBooking.API.Model.Booking
{
    public class TicketDto
    {
        public int BookingId { get; set; }

        //this is delived from the total number of AgeCategoryUnits
        public int TotalNumberOfTicketsTobeBooked { get; set; }

        //this is delived from the total number of AgeCategoryUnits
        public decimal TotalPricePerAgeCategories { get; }
    }
}