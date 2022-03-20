using Newtonsoft.Json;
using Skillsbox.Challenge.MovieBooking.API.Model.Movie;

namespace Skillsbox.Challenge.MovieBooking.API.Service
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<MovieArray>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://college-movies.herokuapp.com/");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var movies = JsonConvert.DeserializeObject<IEnumerable<MovieArray>>(content);

                    if(movies != null)
                    {
                        
                        return movies;
                    }

                    return new List<MovieArray>();
                }

                return new List<MovieArray>();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new List<MovieArray>();
            }
        }
    }
}
