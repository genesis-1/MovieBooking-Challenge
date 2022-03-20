using Newtonsoft.Json;
using Skillsbox.Challenge.MovieBooking.Web.Models;
using Skillsbox.Challenge.MovieBooking.Web.Service.IService;

namespace Skillsbox.Challenge.MovieBooking.Web.Service
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }




        public async Task<Movie> Get(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Movie/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var movie = JsonConvert.DeserializeObject<Movie>(content);
                return movie;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Movie");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var movies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(content);
                    return movies;
                }

                return new List<Movie>();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new List<Movie>();
            }


        }

        
    }
}
