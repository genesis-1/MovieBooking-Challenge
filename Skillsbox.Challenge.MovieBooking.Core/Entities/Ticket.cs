namespace Skillsbox.Challenge.MovieBooking.Core.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int BookingId { get; set; }

        //this is delived from the total number of AgeCategoryUnits
        public int TotalNumberOfTicketsTobeBooked { get; set; }

        //this is delived from the total number of AgeCategoryUnits
        public decimal TotalPricePerAgeCategories{ get; set; }
        ICollection<AgeCategoryDetail> AgeCategoryDetails { get; set;}
    }
}