namespace Skillsbox.Challenge.MovieBooking.API.Model.Movie
{
    public class ProductParametersInfo
    {
        public ProductParametersInfo()
        {
            OrderBy = "ProductRegisterDate";
            PageNumber = 1;
            PageSize = 10;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public string OrderBy { get; set; }
    }
}
