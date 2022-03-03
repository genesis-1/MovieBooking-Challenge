using Skillsbox.Challenge.MovieBooking.Model;

namespace Skillsbox.Challenge.MovieBooking.API
{
    public interface ICategoryService
    {
        public Task<IResult> Create(CategoryDTO objDTO);
        public Task<IResult> Update(CategoryDTO objDTO);
        public Task<IResult> Delete(int id);
        public Task<IResult> Get(int id);
        public Task<IResult> GetAll();
    }
}
