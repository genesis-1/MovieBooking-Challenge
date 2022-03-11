using Skillsbox.Challenge.MovieBooking.Web.Models;

namespace Skillsbox.Challenge.MovieBooking.Web.Service
{
    public interface ICategoryService
    {
        public Task<Category> Create(Category objDTO);
        public Task<Category> Update(Category objDTO);
        public Task Delete(int id);
        public Task<Category> Get(int id);
        public Task<IEnumerable<Category>> GetAll();
    }
}
