namespace Skillsbox.Challenge.MovieBooking.API.Model.Booking
{
    public class AgeCategoryDetailDto
    {
        public string AgeCategoryType { get; set; }
        public int? AgeCategoryUnits { get; set; }
        public decimal UnitPriceForAgeCategory { get; set; }
        public decimal TotalPriceForAnAgeCategory { get; set; }

    }
}
