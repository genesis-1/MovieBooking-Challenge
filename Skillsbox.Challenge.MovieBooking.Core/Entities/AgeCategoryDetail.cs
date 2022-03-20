namespace Skillsbox.Challenge.MovieBooking.Core.Entities
{
    public class AgeCategoryDetail
    {
        public int Id { get; set; }
        public string AgeCategoryType { get; set; }
        public int? TicketId { get; set; }
        public int? AgeCategoryUnits { get; set; }
        public decimal UnitPriceForAgeCategory   { get; set; }
        public decimal TotalPriceForAnAgeCategory { get; set; }
    }
}