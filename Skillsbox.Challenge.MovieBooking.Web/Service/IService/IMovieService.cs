using Skillsbox.Challenge.MovieBooking.Web.Models;

namespace Skillsbox.Challenge.MovieBooking.Web.Service.IService
{
    public interface IMovieService
    {
        public Task<Movie> Get(int id);
        public Task<IEnumerable<Movie>> GetAll();
    }
}
