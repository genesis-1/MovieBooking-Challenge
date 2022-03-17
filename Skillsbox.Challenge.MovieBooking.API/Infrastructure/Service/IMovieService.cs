using Skillsbox.Challenge.MovieBooking.API.Model.Movie;
using System.Threading.Tasks;

namespace Skillsbox.Challenge.MovieBooking.API.Service
{
    public interface IMovieService
    {
        public Task<IEnumerable<MovieArray>> GetAllAsync();
    }
}
