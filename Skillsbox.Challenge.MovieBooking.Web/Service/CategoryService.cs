using Newtonsoft.Json;
using Skillsbox.Challenge.MovieBooking.Web.Models;
using System.Text;

namespace Skillsbox.Challenge.MovieBooking.Web.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Category> Create(Category objDTO)
        {
            try
            {
                var content = JsonConvert.SerializeObject(objDTO);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("/api/category", bodyContent);
                string responseResult = response.Content.ReadAsStringAsync().Result;
                if(response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<Category>(responseResult);
                    return result;
                }
                else
                {
                    var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(responseResult);
                    throw new Exception(errorModel.ErrorMessage);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(int id)
        {


                await _httpClient.DeleteAsync($"/api/category/{id}");

                
        }

        public async Task<Category> Get(int id)
        {
            var response = await _httpClient.GetAsync($"/api/category/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var category = JsonConvert.DeserializeObject<Category>(content);
                return category;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/category");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(content);

                    return categories;
                }

                return new List<Category>();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new List<Category>();
            }
            

        }

        public async Task<Category> Update(Category objDTO)
        {
            var content = JsonConvert.SerializeObject(objDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/category/{objDTO.Id}", bodyContent);
            string responseResult = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<Category>(responseResult);
                return result;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(responseResult);
                throw new Exception(errorModel.ErrorMessage);
            }
        }
    }
}
